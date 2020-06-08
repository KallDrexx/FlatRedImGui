using FlatRedImGui;
using ImGuiNET;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.ImGuiControls
{
    public class SingleBuildingEditor : ImGuiElement
    {
        private readonly Building _building;

        public SingleBuildingEditor(Building building)
        {
            _building = building;
        }

        protected override void CustomRender()
        {
            if (ImGui.Begin($"Selected Building: {_building.BuildingData.NameDisplay}"))
            {
                var health = _building.CurrentHealth;
                ImGui.SliderInt("Health", ref health, 0, _building.BuildingData.Health);
                if (health != _building.CurrentHealth)
                {
                    _building.CurrentHealth = health;
                    _building.UpdateHealthSprite();

                    if (health <= 0)
                    {
                        _building.Destroy();
                    }
                }
            }
            
            ImGui.End();
        }
    }
}