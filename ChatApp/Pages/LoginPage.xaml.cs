using System.Security;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Constructor

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel)
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
