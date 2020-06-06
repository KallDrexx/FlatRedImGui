using ImGuiNET;

namespace FlatRedImGui.ExampleElements
{
    public class DemoWindow : ImGuiElement
    {
        protected override void CustomRender()
        {
            ImGui.ShowDemoWindow();
        }
    }
}