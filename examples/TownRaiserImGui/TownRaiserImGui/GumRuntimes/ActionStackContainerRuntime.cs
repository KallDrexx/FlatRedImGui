using FlatRedBall.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.CustomEvents;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class ActionStackContainerRuntime
    {
        private const int PixelsBetweenButtons = 2;

        public List<IconButtonRuntime> IconButtonList;
        public event EventHandler<TrainUnitEventArgs> TrainUnitInvokedFromButton;
        public event EventHandler<UpdateUiEventArgs> UpdateUIDisplay;

        public event EventHandler<ConstructBuildingEventArgs> SelectBuildingToConstruct;

        partial void CustomInitialize()
        {
            IconButtonList = new List<IconButtonRuntime>();
        }

        private IconButtonRuntime CreateNewIconButtonWithOffset(int stackIndex, ICommonEntityData data, IUpdatesStatus selectedEntity = null)
        {
            IconButtonRuntime button = new IconButtonRuntime();
            button.Parent = this;
            IconButtonList.Add(button);

            button.EntityCreatedFrom = selectedEntity;
            button.HotkeyData = data;

            button.X = stackIndex % 3 != 0 ? PixelsBetweenButtons : 0;
            button.Y = stackIndex > 2 && stackIndex % 3 == 0 ? PixelsBetweenButtons : 0;
            button.RollOn += (notused) =>
            {
                UpdateUIDisplay?.Invoke(this, new UpdateUiEventArgs(data));
            };
            button.RollOff += (notused) =>
            {
                //If we will default to the build menu if an entity is not selected when adding toggle buttons.
                var args = selectedEntity == null ? UpdateUiEventArgs.RollOffValue : new UpdateUiEventArgs() { TitleDisplay = selectedEntity.EntityData.MenuTitleDisplay };

                UpdateUIDisplay?.Invoke(this, args);
            };

            return button;
        }

        public void AddBuildingToggleButtons()
        {
            int i = 0;
            foreach (var buildingData in GlobalContent.BuildingData)
            {
                IconButtonRuntime building = CreateNewIconButtonWithOffset(i, buildingData.Value);

                building.Click += (notused) =>
                {
                    if (building.Enabled)
                    {
                        this.SelectBuildingToConstruct?.Invoke(building, new ConstructBuildingEventArgs { BuildingData = buildingData.Value });
                        RemoveIconButtons();
                    }
                };

                i++;
            }
        }

        public void AddUnitToggleButtons()
        {
            int i = 0;
            foreach (var unitData in GlobalContent.UnitData)
            {
                bool shouldAddButton = unitData.Value.IsEnemy == false;
#if DEBUG
                shouldAddButton |= Entities.DebuggingVariables.ShouldAddEnemiesToActionToolbar;
#endif
                if (shouldAddButton)
                {
                    IconButtonRuntime unit = CreateNewIconButtonWithOffset(i, unitData.Value);

                    unit.Click += (notused) =>
                    {
                    };


                    i++;
                }
            }
        }

        public void RefreshToggleButtonsTo(IUpdatesStatus selectedEntity)
        {
            RemoveIconButtons();

            if(selectedEntity?.ButtonDatas != null)
            {
                int i = 0;
                foreach (var unit in selectedEntity.ButtonDatas)
                {
                    var unitData = GlobalContent.UnitData[unit];
                    IconButtonRuntime unitButton = CreateNewIconButtonWithOffset(i, unitData, selectedEntity);

                    unitButton.HotkeyData = unitData;

                    unitButton.Click += (notused) =>
                    {
                        if (unitButton.Enabled)
                        {
                            this.TrainUnitInvokedFromButton(unitButton, new TrainUnitEventArgs() { UnitData = unitData });
                        }

                    };

                    i++;
                }
            }
        }

        public void RemoveIconButtons()
        {
            for(int i = IconButtonList.Count -1; i > -1; i--)
            {
                var toggleButton = IconButtonList[i];

                Children.Remove(toggleButton);
                IconButtonList.Remove(toggleButton);

                toggleButton.EntityCreatedFrom = null;
                toggleButton.Destroy();
                toggleButton = null;
            }

        }
        public void UpdateIconCoolDown(IUpdatesStatus selectedEntity)
        {
            foreach(var button in this.IconButtonList)
            {
                button.UpdateDisplayFromEntiy(selectedEntity);
            }
        }
    }
}
