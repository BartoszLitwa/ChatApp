using ChatApp.Core;
using Dna;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
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
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

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
        public ObservableCollection<ChatMessageListItemViewModel> Items
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
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat list thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

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

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when the user clicks the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

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

        #endregion

        #region Constructor

        /// <summary>
        /// Default constrctor
        /// </summary>
        public ChatMessageListViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickAwayCommand = new RelayCommand(PopupClickAway);
            SendCommand = new RelayCommand(async () => await SendMessageAsync());
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            // Make a default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the popup clickaway area is clicked show/hide any popups
        /// </summary>
        public void PopupClickAway()
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// When the user clicks the send button sends the message
        /// </summary>
        public async Task SendMessageAsync()
        {
            // If message is empty
            if (string.IsNullOrEmpty(PendingMessageText))
                // Dont do anything
                return;

            // Ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            if (FilteredItems == null)
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>();

            // Get login Credentials
            var loginCredentials = await ClientDataStore.GetLoginCredentialsAsync();

            // If we dont have stored login credentials
            if (loginCredentials == null || string.IsNullOrEmpty(loginCredentials.Token))
                return;

            // Create new message
            var message = new ChatMessageListItemViewModel
            {
                Initials = "BL",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                ProfilePictureRGB = "ffffff",
                SentByMe = true,
                SenderName = loginCredentials.Username,
                NewItem = true,
            };

            // Create the 
            var result = new Dna.WebRequestResult<ApiResponse>();

            if (Items.Count == 0)
            {
                result = await WebRequests.PostAsync<ApiResponse>(RouteHelpers.GetAbsoluteRoute(ContactsRoutes.CreateMessageHistory),
                   new TableApiModel
                   {
                       Username = message.SentByMe ? loginCredentials.Username : SenderName,
                       SecondUser = message.SentByMe ? SenderName : loginCredentials.Username
                   },
                   bearerToken: loginCredentials.Token);
            }

            result = await WebRequests.PostAsync<ApiResponse>(RouteHelpers.GetAbsoluteRoute(ContactsRoutes.SendMessage),
                new MessageApiModel
                {
                    SendTo = SenderName,
                    SendBy = loginCredentials.Username,
                    Message = PendingMessageText,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.MinValue,
                    ImageAttachment = message.ImageAttachment != null,
                    ImageAttachmentURL = message.ImageAttachment != null ? message.ImageAttachment.ThumbnailUrl : ""
                },
                bearerToken: loginCredentials.Token);

            // If it was successful
            if (result.Successful)
            {
                Items.Add(message);
                FilteredItems.Add(message);

                // Clear the pending message text
                PendingMessageText = string.Empty;
            }
            else
            {
                await UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Unsuccessful sending message",
                    Message = $"{result.ServerResponse.Response ?? "Error occured while sending"}"
                });
            }
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
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                // Set last search
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            // Set last search
            mLastSearchText = SearchText;

            if(FilteredItems.Count <= 0)
            {
                // Show message that there isnt any message containg the search text
                UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Message = "Any message doesn't contain the search text!",
                    Title = "No messages",
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

        #endregion
    }
}
