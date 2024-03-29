﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// A view model for a friend thread list
    /// </summary>
    public class FriendListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The chat list thread items for the list
        /// </summary>
        protected ObservableCollection<FriendListItemViewModel> mItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properites

        /// <summary>
        /// The chat list thread items for the list
        /// NOTE: Do not call Items to add messages to this list
        ///       as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<FriendListItemViewModel> Items
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update the value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<FriendListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat list thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<FriendListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any poup menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The display name of the sender name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// The initials to show for the profile backgorund
        /// </summary>
        public string SenderInitials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example #ffffff white
        /// </summary>
        public string SenderProfilePictureRGB { get; set; }

        /// <summary>
        /// The text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Make sure value has changed
                if (mSearchText == value)
                    return;

                // Update the value
                mSearchText = value;

                if (!string.IsNullOrEmpty(SearchText))
                    //Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Make sure value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update the value
                mSearchIsOpen = value;

                // If dialog closes
                if (!mSearchIsOpen)
                    // Clear search text
                    SearchText = string.Empty;
            }
        }

        /// <summary>
        /// A flag indicating if the Refreshing Friend List is runnign
        /// </summary>
        public bool RefreshIsRunning { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to open the search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close the search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to clear the search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to refresh list of friends
        /// </summary>
        public ICommand RefreshFriendsCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constrctor
        /// </summary>
        public FriendListViewModel()
        {
            // Create commands
            PopupClickAwayCommand = new RelayCommand(PopupClickAway);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);
            RefreshFriendsCommand = new RelayCommand(async () => await RefreshFriendListAsync());

            // Make a default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the popup clickaway area is clicked show/hide any popups
        /// </summary>
        public void PopupClickAway()
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            // Make sure we dont re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) || string.Equals(mLastSearchText, SearchText))
                return;

            if(string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<FriendListItemViewModel>(Items);

                // Set last search
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<FriendListItemViewModel>(Items.Where(item => item.Name.ToLower().Contains(SearchText) || item.Username.ToLower().Contains(SearchText)));

            // Set last search
            mLastSearchText = SearchText;

            if(FilteredItems.Count <= 0)
            {
                // Show message that there isnt any message containg the search text
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Message = "Any of Your friends match the search text.",
                    Title = "No Friends",
                });
            }
        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Close the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(SearchText))
            {
                // Clear the text
                SearchText = string.Empty;

                // Search the items
                Search();
            }
            else
                // Close the search bar
                SearchIsOpen = false;
        }

        public async Task<bool> RefreshFriendListAsync()
        {
            await RunCommandAsync(() => RefreshIsRunning, async () =>
            {
                await Task.Delay(3000);
            });

            return false;
        }

        #endregion
    }
}
