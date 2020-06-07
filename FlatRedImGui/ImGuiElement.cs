namespace FlatRedImGui
{
    /// <summary>
    /// Represents a set of UI controls that can be manipulated and rendered
    /// </summary>
    public abstract class ImGuiElement
    {
        public bool IsVisible { get; set; }
        public bool HasFocus { get; set; }

        public void Render()
        {
            if (IsVisible)
            {
                CustomRender();
            }
        }
        
        /// <summary>
        /// Custom logic for each item for how the item should be rendered.  This will only be called if the element
        /// has `IsVisible` set to `true`.
        /// </summary>
        protected abstract void CustomRender();
    }
}