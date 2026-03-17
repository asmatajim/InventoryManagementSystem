using KTMPOS.BAL.Services.Users;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Users;
using KTMPOS.Desktop.Utilities;

using Microsoft.Extensions.DependencyInjection;

using System.Data;

namespace KTMPOS.Desktop.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitializeFormComponent();
            _serviceProvider = serviceProvider;
        }

        private void InitializeFormComponent()
        {
            KeyPreview = true;
            AcceptButton = btnSave;
            txtUserName.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnSave.TabIndex = 2;
            btnCancel.TabIndex = 3;
            txtPassword.PasswordChar = '*';
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                await LoginAsync();
            }
            else if(e.KeyCode == Keys.F3)
            {
                Application.Exit();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private void ResetControls()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private async Task LoginAsync()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            var loginService = _serviceProvider.GetRequiredService<ILoginService>();
            LoginRequest request = new()
            {
                UserName = userName,
                Password = password
            };
            var result = await loginService.AuthenticateAsync(request);
            if(result.Status == Status.Success)
            {
                int userId = result
                             .Data
                             .Select(x => x.Id)
                             .FirstOrDefault();
                var form = _serviceProvider.GetRequiredService<POSMainForm>();
                form.UserId = userId;
                form.Show();
                Hide();
                return;
            }

            DialogMessage.FailedAlert(result);
            ResetControls();
        }
    }
}