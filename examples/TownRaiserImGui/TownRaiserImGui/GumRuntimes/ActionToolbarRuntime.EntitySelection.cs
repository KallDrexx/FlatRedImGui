using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.CustomEvents;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class ActionToolbarRuntime
    {
        private IUpdatesStatus m_LastSelectedEntity;


        public void SetViewFromEntity(IUpdatesStatus selectedEntity)
        {
            //Player selected a different entity
            if (m_LastSelectedEntity != null && m_LastSelectedEntity != selectedEntity)
            {
                m_LastSelectedEntity.UpdateStatus -= ReactToBuilidingStatusChange;
                ActionStackContainerInstance.RemoveIconButtons();
            }
            m_LastSelectedEntity = selectedEntity;

            if (m_LastSelectedEntity == null)
            {
                ActionStackContainerInstance.RemoveIconButtons();
                SetVariableState(VariableState.SelectModeView);
            }
            else if (m_LastSelectedEntity is Entities.Building)
            {
                this.ResourceCostContainer.CurrentMenuTypeState = ResourceCostContainerRuntime.MenuType.TrainUnits;
                UpdateBuildingStatus(m_LastSelectedEntity as Entities.Building);
                SetVariableState(VariableState.SelectedEntity);
                m_LastSelectedEntity.UpdateStatus += ReactToBuilidingStatusChange;
                ShowAvailableUnits(m_LastSelectedEntity);
            }

            if (m_LastSelectedEntity != null)
            {
                this.ReactToUpdateUiChangeEvent(this, new UpdateUiEventArgs() { TitleDisplay = m_LastSelectedEntity.EntityData.MenuTitleDisplay });
            }
        }

        private void ReactToBuilidingStatusChange(object sender, UpdateStatusEventArgs args)
        {
            var building = sender as Entities.Building;
            if (building != null)
            {
                if (args.WasEntityDestroyed == false)
                {
                    UpdateBuildingStatus(building);

                }
                else
                {
                    this.SetVariableState(VariableState.SelectModeView);
                }
            }
        }

        private void UpdateBuildingStatus(Entities.Building building)
        {
            UpdateHealthState(building);
            UpdateBuilidngTrainingStatus(building);
        }
        private void UpdateHealthState(IUpdatesStatus entity)
        {
            //ToDo: Discuss a health view option.
        }
        private void UpdateBuilidngTrainingStatus(Entities.Building building)
        {
            ActionStackContainerInstance.UpdateIconCoolDown(building);
        }
    }
}
