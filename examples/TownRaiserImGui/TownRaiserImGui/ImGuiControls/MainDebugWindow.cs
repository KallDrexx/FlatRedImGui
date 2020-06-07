using System.Collections.Generic;
using FlatRedImGui;
using ImGuiNET;

namespace TownRaiserImGui.ImGuiControls
{
    public class MainDebugWindow : ImGuiElement
    {
        private readonly List<GlobalUnitEditor> _globalUnitEditors = new List<GlobalUnitEditor>();
        private Dictionary<GlobalUnitEditor, bool> _unitEditorExpandedMap = new Dictionary<GlobalUnitEditor, bool>();
        
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

        public void Add(GlobalUnitEditor globalUnitEditor)
        {
            _globalUnitEditors.Add(globalUnitEditor);
            _unitEditorExpandedMap[globalUnitEditor] = false;
        }

        protected override void CustomRender()
        {
            if (ImGui.Begin("Main Debug Window", ImGuiWindowFlags.None))
            {
                var framerate = ImGui.GetIO().Framerate;
                ImGui.Text($"Frame time: {(1000f / framerate):F3} ms/frame");
                ImGui.Text($"Framerate: {framerate:F1} FPS");
                
                if (ImGui.CollapsingHeader("Available Resources"))
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

                if (ImGui.CollapsingHeader("Unit / Building Data"))
                {
                    if (ImGui.TreeNode("Units"))
                    {
                        foreach (var globalUnitEditor in _globalUnitEditors)
                        {
                            if (_unitEditorExpandedMap[globalUnitEditor])
                            {
                                ImGui.SetNextItemOpen(true);
                            }
                            
                            if (ImGui.TreeNode(globalUnitEditor.Id, globalUnitEditor.DisplayName))
                            {
                                _unitEditorExpandedMap[globalUnitEditor] = true;
                                globalUnitEditor.Render();
                                
                                ImGui.TreePop();
                            }
                            else
                            {
                                _unitEditorExpandedMap[globalUnitEditor] = false;
                            }
                        }
                        
                        ImGui.TreePop();
                    }
                }
            }
            
            ImGui.End();
        }
    }
}