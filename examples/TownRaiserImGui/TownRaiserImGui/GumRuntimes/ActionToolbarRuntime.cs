using Gum.Wireframe;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;
using TownRaiserImGui.Screens;
using TownRaiserImGui.Entities;
using TownRaiserImGui.CustomEvents;
using TownRaiserImGui.Interfaces;
using FlatRedBall.Screens;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class ActionToolbarRuntime
    {
        public event EventHandler<TrainUnitEventArgs> TrainUnitInvokedFromActionToolbar;

        public BuildingData SelectedBuildingData
        {
            get
            {
                BuildingData toReturn = null;
                if(this.CurrentVariableState == VariableState.PlacingBuilding)
                {
                    toReturn = this.SelectedBuilding.HotKeyDataAsBuildingData;
                }
                return toReturn;
            }
        }

        public ActionMode GetActionStateBaseOnUi()
        {

            if (this.CurrentVariableState == VariableState.PlacingBuilding) return ActionMode.Build;
            ////else if (BuildButtonInstance.IsOn && anySubButtonSelected) return ActionMode.Build;
            //else return ActionMode.Select;
            return ActionMode.Select;
        }

        partial void CustomInitialize()
        {
            this.RaiseChildrenEventsOutsideOfBounds = true;
            this.BuildMenuButtonInstance.Click += (notused) =>
            {
                this.AddBuildingOptionsToActionPanel();
            };
            this.ActionStackContainerInstance.TrainUnitInvokedFromButton += (notUsed, args) =>
            {
                this.TrainUnitInvokedFromActionToolbar(notUsed, args);
                //Update the Ui for the case that we cannot afford a unit after clicking the button.
                //This should not effect hot key presses. Since they will invoke the local TrainUnit Event directly
                ReactToUpdateUiChangeEvent(null, new UpdateUiEventArgs(args.UnitData));
            };
            this.XButtonInstance.Click += (notused) =>
            {
                this.PerformCancelStep();
            };
            this.SetVariableState(VariableState.SelectModeView);
            this.ActionStackContainerInstance.UpdateUIDisplay += ReactToUpdateUiChangeEvent;
            this.ActionStackContainerInstance.SelectBuildingToConstruct += ReactToBuildingButtonClick;
        }

        public void UpdateCostUiFromLastRollOver()
        {
            this.ResourceCostContainer.UpdateFromLastRollOverData();
        }
        public void ReactToUpdateUiChangeEvent(object sender, UpdateUiEventArgs args)
        {
            this.MenuTitleDisplayText = args.TitleDisplay;
            this.ResourceCostContainer.UpadteResourceDisplayText(args);
        }
        public void ReactToBuildingButtonClick(object sender, ConstructBuildingEventArgs args)
        {
            this.SetVariableState( VariableState.PlacingBuilding);
            this.SelectedBuilding.HotkeyData = args.BuildingData;
        }
        public void SetActionMode(ActionMode modeToSetTo)
        {
            //We will have this in case something outside wants a specific selection state.
            switch(modeToSetTo)
            {
                case ActionMode.Select:
                    this.ActionStackContainerInstance.RemoveIconButtons();
                    this.SetVariableState(VariableState.SelectModeView);
                    break;
            }
        }
        private void SetVariableState(VariableState state)
        {
            switch(state)
            {
                case VariableState.SelectModeView:
                case VariableState.PlacingBuilding:
                    this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    this.Width = 32;
                    this.Height = 32;
                    break;
                case VariableState.BuildMenuSelected:
                case VariableState.SelectedEntity:
                    this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                    this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                    this.Width = 8;
                    this.Height = 8;
                    ReactToUpdateUiChangeEvent(null, UpdateUiEventArgs.RollOffValue);
                    break;
            }

            this.CurrentVariableState = state;
        }
        public void ShowAvailableUnits(IUpdatesStatus selectedEntity)
        {
            ActionStackContainerInstance.RefreshToggleButtonsTo(selectedEntity);
            SetVariableState(VariableState.SelectedEntity);
        }

        private void AddBuildingOptionsToActionPanel()
        {
            bool addButtons = ActionStackContainerInstance.IconButtonList.Count == 0;
#if DEBUG
            addButtons &= Entities.DebuggingVariables.DoNotAddActionPanelButtons == false;
#endif
            if (addButtons)
            {
                this.SetVariableState(VariableState.BuildMenuSelected);
                this.ResourceCostContainer.CurrentMenuTypeState = ResourceCostContainerRuntime.MenuType.BuildMenu;

                ActionStackContainerInstance.AddBuildingToggleButtons();
            }
        }

        private void AddUnitOptionsToActionPanel(IUpdatesStatus units = null)
        {
            ActionStackContainerInstance.RefreshToggleButtonsTo(units);
        }

        public void ReactToKeyPress()
        {
            if(InputManager.Keyboard.KeyPushed(Keys.Escape)) //The escape case depends on the currently selected default button and if a sub button is selected.
            {
                PerformCancelStep();

            }
            else if(this.CurrentVariableState == VariableState.SelectModeView && InputManager.Keyboard.KeyPushed(Keys.B))
            {

                AddBuildingOptionsToActionPanel();

            }
            else
            {
                foreach(var button in ActionStackContainerInstance.IconButtonList)
                {
                    var hotKey = button.HotkeyData.Hotkey;
                    if(InputManager.Keyboard.KeyPushed(hotKey))
                    {
                        switch(this.CurrentVariableState)
                        {
                            case VariableState.SelectedEntity:
                                //Selected entity may have different cases for using an ability.
                                if(button.HotKeyDataAsUnitData != null)
                                {
                                    this.TrainUnitInvokedFromActionToolbar(null, new TrainUnitEventArgs() { UnitData = button.HotKeyDataAsUnitData });
                                }
                                break;
                            case VariableState.BuildMenuSelected:
                                if (button.HotKeyDataAsBuildingData != null)
                                {
                                    //Only allow hotkey to go through if button is enabled.
                                    if (button.Enabled)
                                    {
                                        ReactToBuildingButtonClick(null, new ConstructBuildingEventArgs { BuildingData = button.HotKeyDataAsBuildingData });
                                    }
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void PerformCancelStep()
        {
            switch(this.CurrentVariableState)
            {
                case VariableState.PlacingBuilding:
                    this.ActionStackContainerInstance.RemoveIconButtons();
                    AddBuildingOptionsToActionPanel();
                    break;
                case VariableState.BuildMenuSelected:
                case VariableState.SelectedEntity:
                    ((GameScreen)ScreenManager.CurrentScreen).DeselectBuilding();
                    ActionStackContainerInstance.RemoveIconButtons();
                    this.SetVariableState(VariableState.SelectModeView);
                    break;
            }
        }

        public void UpdateButtonEnabledStates(int lumber, int stone, int gold, int currentCapacity, int maxCapacity, IEnumerable<Building> existingBuildings, IUpdatesStatus selectedBuilding)
        {
            foreach (var button in ActionStackContainerInstance.IconButtonList)
            {
                button.UpdateButtonEnabledState(lumber, stone, gold, currentCapacity, maxCapacity, existingBuildings, selectedBuilding);
            }
        }
    }
}
