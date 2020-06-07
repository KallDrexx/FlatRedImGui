using FlatRedImGui;

namespace TownRaiserImGui.ImGui
{
    public class DemoWindow : ImGuiElement
    {
        protected override void CustomRender()
        {
            ImGuiNET.ImGui.ShowDemoWindow();
        }
    }
}