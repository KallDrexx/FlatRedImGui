using FlatRedImGui;

namespace TownRaiserImGui.ImGuiControls
{
    public class DemoWindow : ImGuiElement
    {
        protected override void CustomRender()
        {
            ImGuiNET.ImGui.ShowDemoWindow();
        }
    }
}