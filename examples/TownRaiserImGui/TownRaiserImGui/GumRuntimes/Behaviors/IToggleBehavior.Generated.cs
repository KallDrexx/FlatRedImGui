    namespace TownRaiserImGui.GumRuntimes
    {
        #region State Enums
        public enum ToggleBehaviorToggleCategory
        {
            EnabledOn,
            EnabledOff,
            DisabledOn,
            DisabledOff,
            HighlightedOn,
            HighlightedOff,
            PushedOn,
            PushedOff
        }
        #endregion
        public interface IToggleBehavior
        {
            ToggleBehaviorToggleCategory CurrentToggleBehaviorToggleCategoryState {set;}
        }
    }
