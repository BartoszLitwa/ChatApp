using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// The design-time data for a <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MenuDesignModel Instance = new MenuDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel
                {
                    Type = MenuItemType.Header,
                    Text = "Design Time Header",
                },
                new MenuItemViewModel
                {
                    Icon = IconType.File,
                    Text = "Menu Item 1",
                },
                new MenuItemViewModel
                {
                    Icon = IconType.Picture,
                    Text = "Menu Item 2",
                },
            });
        }

        #endregion
    }
}
