namespace ChatApp.Core
{
    /// <summary>
    /// The type of items for a menu item
    /// </summary>
    public enum MenuItemType
    {
        /// <summary>
        /// Shows the menu text and an icon
        /// </summary>
        TextAndIcon = 0,

        /// <summary>
        /// Shows a simple divider between  the menu items
        /// </summary>
        Divider = 1,

        /// <summary>
        /// Showis the menu text as a header
        /// </summary>
        Header = 2,
    }
}
