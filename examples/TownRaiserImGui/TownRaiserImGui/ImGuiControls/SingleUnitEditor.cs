using System;
using System.Linq;
using System.Numerics;
using FlatRedImGui;
using ImGuiNET;
using TownRaiserImGui.Entities;
using TownRaiserImGui.Screens;

namespace TownRaiserImGui.ImGuiControls
{
    public class SingleUnitEditor : ImGuiElement
    {
        private static readonly string[] ResourceTypes = {"<None>", "Gold", "Lumber", "Stone"};
        private readonly Unit _unit;

        public SingleUnitEditor(Unit unit)
        {
            _unit = unit;
        }
        
        protected override void CustomRender()
        {
            if (ImGui.Begin($"Selected Unit: {_unit.UnitData.NameDisplay}"))
            {
                var health = _unit.CurrentHealth;
                ImGui.SliderInt("Health", ref health, 0, _unit.UnitData.Health);
                if (health != _unit.CurrentHealth)
                {
                    _unit.CurrentHealth = health;
                    _unit.UpdateHealthSprite();

                    if (health <= 0)
                    {
                        _unit.PerformDeath();
                    }
                }

                DisplayResourceTypeComboBox();
                GoalsDisplay();
            }
            
            ImGui.End();
        }

        private void DisplayResourceTypeComboBox()
        {
            var currentResourceTypeIndex = _unit.ResourceTypeToReturn switch
            {
                null => 0,
                ResourceType.Gold => 1,
                ResourceType.Lumber => 2,
                ResourceType.Stone => 3,
                _ => throw new NotSupportedException($"Resource type {_unit.ResourceTypeToReturn} is not supported")
            };

            ImGui.Combo("Returning Resource Type", ref currentResourceTypeIndex, ResourceTypes, ResourceTypes.Length);

            var selectedResource = currentResourceTypeIndex switch
            {
                0 => (ResourceType?) null,
                1 => ResourceType.Gold,
                2 => ResourceType.Lumber,
                3 => ResourceType.Stone,
                _ => throw new NotSupportedException($"Unknown resource index of {currentResourceTypeIndex}")
            };

            if (selectedResource != _unit.ResourceTypeToReturn)
            {
                _unit.SetResourceToReturn(selectedResource);
            }
        }

        private void GoalsDisplay()
        {
            ImGui.Separator();
            ImGui.Text("High Level Goals");

            var isFirst = true;
            foreach (var goal in _unit.HighLevelGoals)
            {
                if (isFirst)
                {
                    ImGui.TextColored(new Vector4(1.0f, 1.0f, 0.0f, 1.0f), goal.GetType().Name);
                    isFirst = false;
                }
                else
                {
                    ImGui.Text(goal.GetType().Name);
                }
            }

            if (!_unit.HighLevelGoals.Any())
            {
                ImGui.TextColored(new Vector4(1f, 0f, 0f, 1f), "<No Goals>");
            }
        }
    }
}