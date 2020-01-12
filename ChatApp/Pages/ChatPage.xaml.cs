using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when thew viewmodel changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            // Make sure UI exists first
            if (ChatMessageList == null)
                return;

            // Fade in chat message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            // Make the message box focused
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// Preview the input the message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Get the textbox
            var textbox = sender as TextBox;

            // Check if we have pressed enter and ctrl
            if (e.Key == Key.Enter)
            {
                // If we have control pressed
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    // Add a new line at the point where cursor is
                    var index = textbox.CaretIndex;

                    // Insert the new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    // Shft the caret forward to the newline
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    // Mark this key as handled by us
                    e.Handled = true;
                }
                else
                    //Send the message
                    ViewModel.SendMessage();

                // Mark this key as handled by us
                e.Handled = true;
            }
        }
    }
}
