using System;
using System.ComponentModel.Composition;
using FlatRedBall.Glue;
using FlatRedBall.Glue.Plugins;
using FlatRedBall.Glue.Plugins.Interfaces;

namespace FlatRedImGuiGluePlugin
{
    [Export(typeof(PluginBase))]
    public class MainPlugin : PluginBase
    {
        public override string FriendlyName => "FlatRedImGui (Dear ImGui Integration)";
        public override Version Version => new Version(0, 0, 1);
        
        public override void StartUp()
        {
            ReactToLoadedGlux += HandleReactToLoadedGlux;
        }

        public override bool ShutDown(PluginShutDownReason shutDownReason)
        {
            return true;
        }
        
        private void HandleReactToLoadedGlux()
        {
            
        }
    }
}