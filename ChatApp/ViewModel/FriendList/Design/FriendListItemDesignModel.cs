using ChatApp.Core;
using System;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="FriendListItemDesignModel"/>
    /// </summary>
    public class FriendListItemDesignModel : FriendListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static FriendListItemDesignModel Instance => new FriendListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Username = "CRNYY";
            ProfilePictureRGB = "ff0000";
            AddTime = DateTimeOffset.UtcNow;
        }

        #endregion
    }
}
