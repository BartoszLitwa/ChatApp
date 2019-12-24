using ChatApp.Core;
using System.Security;



namespace ChatApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The secure password for this login
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
