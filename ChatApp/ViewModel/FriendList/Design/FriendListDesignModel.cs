using System;
using System.Collections.ObjectModel;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="FriendListDesignModel"/>
    /// </summary>
    public class FriendListDesignModel : FriendListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static FriendListDesignModel Instance => new FriendListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FriendListDesignModel()
        {
            Items = new ObservableCollection<FriendListItemViewModel> {

                new FriendListItemViewModel
                {
                    Name = "Luke Parnell",
                    Username = "Test",
                    Initials = "LP",
                    ProfilePictureRGB = "00ff00",
                    AddTime = DateTimeOffset.UtcNow,
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test",
                    Username = "Test1",
                    Initials = "LM",
                    ProfilePictureRGB = "ff0000",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test2",
                    Username = "Test2",
                    Initials = "LM",
                    ProfilePictureRGB = "0000ff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test3",
                    Username = "Test3",
                    Initials = "LM",
                    ProfilePictureRGB = "ffff00",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(3.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test4",
                    Username = "Test4",
                    Initials = "LM",
                    ProfilePictureRGB = "00ffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(4.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test5",
                    Username = "Test5",
                    Initials = "LM",
                    ProfilePictureRGB = "ffffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(5.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Parnell",
                    Username = "Test",
                    Initials = "LP",
                    ProfilePictureRGB = "00ff00",
                    AddTime = DateTimeOffset.UtcNow,
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test",
                    Username = "Test1",
                    Initials = "LM",
                    ProfilePictureRGB = "ff0000",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test2",
                    Username = "Test2",
                    Initials = "LM",
                    ProfilePictureRGB = "0000ff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test3",
                    Username = "Test3",
                    Initials = "LM",
                    ProfilePictureRGB = "ffff00",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(3.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test4",
                    Username = "Test4",
                    Initials = "LM",
                    ProfilePictureRGB = "00ffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(4.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test5",
                    Username = "Test5",
                    Initials = "LM",
                    ProfilePictureRGB = "ffffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(5.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Parnell",
                    Username = "Test",
                    Initials = "LP",
                    ProfilePictureRGB = "00ff00",
                    AddTime = DateTimeOffset.UtcNow,
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test",
                    Username = "Test1",
                    Initials = "LM",
                    ProfilePictureRGB = "ff0000",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test2",
                    Username = "Test2",
                    Initials = "LM",
                    ProfilePictureRGB = "0000ff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test3",
                    Username = "Test3",
                    Initials = "LM",
                    ProfilePictureRGB = "ffff00",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(3.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test4",
                    Username = "Test4",
                    Initials = "LM",
                    ProfilePictureRGB = "00ffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(4.3)),
                },
                new FriendListItemViewModel
                {
                    Name = "Luke Test5",
                    Username = "Test5",
                    Initials = "LM",
                    ProfilePictureRGB = "ffffff",
                    AddTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(5.3)),
                },
            };
        }

        #endregion
    }
}
