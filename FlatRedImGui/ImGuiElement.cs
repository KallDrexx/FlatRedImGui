using System.Collections.Generic;

namespace FlatRedImGui
{
    /// <summary>
    /// Represents a set of UI controls that can be manipulated and rendered
    /// </summary>
    public abstract class ImGuiElement
    {
        protected List<ImGuiElement> Children { get; } = new List<ImGuiElement>();
        public bool IsVisible { get; set; }

        public void Render()
        {
            if (IsVisible)
            {
                CustomRender();

                foreach (var child in Children)
                {
                    child.Render();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected abstract void CustomRender();
    }
}