using ChatApp.Core;
using System.Security;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        #region Constructor

        public RegisterPage()
        {
            InitializeComponent();
        }

        public RegisterPage(RegisterViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// The secure password for this login
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
