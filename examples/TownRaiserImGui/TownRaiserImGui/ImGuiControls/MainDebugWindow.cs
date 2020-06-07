using FlatRedImGui;
using ImGuiNET;

namespace TownRaiserImGui.ImGuiControls
{
    public class MainDebugWindow : ImGuiElement
    {
        public int GoldCount
        {
            get => Get<int>();
            set => Set(value);
        }

        public int LumberCount
        {
            get => Get<int>();
            set => Set(value);
        }

        public int StoneCount
        {
            get => Get<int>();
            set => Set(value);
        }
        
        protected override void CustomRender()
        {
            if (ImGui.Begin("Main Debug Window", ImGuiWindowFlags.None))
            {
                var framerate = ImGui.GetIO().Framerate;
                ImGui.Text($"Frame time: {(1000f / framerate):F3} ms/frame");
                ImGui.Text($"Framerate: {framerate:F1} FPS");
                
                if (ImGui.CollapsingHeader("Resources"))
                {
                    ImGui.LabelText("Resource", "Count");

                    var gold = GoldCount;
                    ImGui.InputInt("Gold", ref gold, 1);
                    GoldCount = gold;

                    var lumber = LumberCount;
                    ImGui.InputInt("Lumber", ref lumber, 1);
                    LumberCount = lumber;

                    var stone = StoneCount;
                    ImGui.InputInt("Stone", ref stone, 1);
                    StoneCount = stone;
                }
            }
            
            ImGui.End();
        }
    }
}