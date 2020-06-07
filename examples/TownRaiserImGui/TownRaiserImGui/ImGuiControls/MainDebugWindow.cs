using System.Collections.Generic;
using FlatRedImGui;
using ImGuiNET;

namespace TownRaiserImGui.ImGuiControls
{
    public class MainDebugWindow : ImGuiElement
    {
        private readonly List<GlobalUnitEditor> _globalUnitEditors = new List<GlobalUnitEditor>();
        private readonly List<GlobalBuildingEditor> _globalBuildingEditors = new List<GlobalBuildingEditor>();
        
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

        public bool MuteMusic
        {
            get => Get<bool>();
            set => Set(value);
        }

        public void Add(GlobalUnitEditor globalUnitEditor)
        {
            _globalUnitEditors.Add(globalUnitEditor);
        }

        public void Add(GlobalBuildingEditor globalBuildingEditor)
        {
            _globalBuildingEditors.Add(globalBuildingEditor);
        }

        protected override void CustomRender()
        {
            if (ImGui.Begin("Main Debug Window", ImGuiWindowFlags.None))
            {
                var framerate = ImGui.GetIO().Framerate;
                ImGui.Text($"Frame time: {(1000f / framerate):F3} ms/frame");
                ImGui.Text($"Framerate: {framerate:F1} FPS");
                
                ImGui.NewLine();

                Checkbox(nameof(MuteMusic), "Mute Music");
                if (ImGui.CollapsingHeader("Available Resources"))
                {
                    ImGui.LabelText("Resource", "Count");
                    
                    InputInt(nameof(GoldCount), "Gold");
                    InputInt(nameof(LumberCount), "Lumber");
                    InputInt(nameof(StoneCount), "Stone");
                }

                if (ImGui.CollapsingHeader("Unit / Building Data"))
                {
                    if (ImGui.TreeNode("Units"))
                    {
                        foreach (var globalUnitEditor in _globalUnitEditors)
                        {
                            if (ImGui.TreeNode(globalUnitEditor.UnitId, globalUnitEditor.DisplayName))
                            {
                                globalUnitEditor.IsVisible = true; // Unit editor should always be visible
                                globalUnitEditor.Render();
                                
                                ImGui.TreePop();
                            }
                        }
                        
                        ImGui.TreePop();
                    }

                    if (ImGui.TreeNode("Buildings"))
                    {
                        foreach (var editor in _globalBuildingEditors)
                        {
                            if (ImGui.TreeNode(editor.BuildingId, editor.DisplayName))
                            {
                                editor.IsVisible = true;
                                editor.Render();
                                
                                ImGui.TreePop();
                            }
                        }
                    }
                }
            }
            
            ImGui.End();
        }
    }
}