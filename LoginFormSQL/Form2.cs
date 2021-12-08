using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace LoginFormSQL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "5gqB2S9edlaM4KqTXJ7vlqqk5nVMLPlvS8AhVn4e",
            BasePath = "https://loginformcsharp-5b967-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            signinForm signinPage = new signinForm();
            this.Hide();
            signinPage.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);

            }
            catch
            {
                MessageBox.Show("Problem in the internet!");
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(usernameBox.Text) || string.IsNullOrEmpty(passwordBox.Text) )
            {
                MessageBox.Show("Please enter your account!");
            }
            else
            {
                FirebaseResponse response = client.Get("UserList/");
                Dictionary<string, User> result = response.ResultAs<Dictionary<string, User>>();
                string usernameResult = "";
                string passwordResult = "";
                foreach (var get in result)
                {
                     usernameResult = get.Value.username;
                     passwordResult = get.Value.password;
                    if (usernameBox.Text == usernameResult)
                    {
                        if (passwordBox.Text == passwordResult) break;
                        else MessageBox.Show("Wrong password!");
                    }
                }
                if (usernameResult == "") MessageBox.Show("Account does not exist! Create new acount now!");
                else
                {
                    //MessageBox.Show("Wellcom " + usernameBox.Text);
                    //đóng cửa sổ đăng nhập và mở cửa số home
                    this.Hide();
                    homeForm homePage = new homeForm();
                    homePage.Show();
                }                                                                                  
            }    
        }
        
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            passwordBox.PasswordChar = showPassword.Checked ? '\0' : '\u25CF';
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
