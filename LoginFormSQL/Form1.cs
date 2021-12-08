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
    public partial class signinForm : Form
    {
        
        public signinForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "5gqB2S9edlaM4KqTXJ7vlqqk5nVMLPlvS8AhVn4e",
            BasePath = "https://loginformcsharp-5b967-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient client;

      
        private void Form1_Load(object sender, EventArgs e)
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

        String confirmPass = "";
        private void signInBtn_Click(object sender, EventArgs e)
        {
            confirmPass = confirmPassBox.Text;
            User user = new User()
            {
                username = usernameBox.Text,
                password = passwordBox.Text,
                ID = idBox.Text
            };
            if(confirmPass == passwordBox.Text)
            {
                var setter  =client.Set("UserList/"+idBox.Text, user);
                MessageBox.Show("Sign in done !");
                //đóng cửa sổ đăng kí và mở cửa số đăng nhập
                this.Hide();
                LoginForm loginPage = new LoginForm();
                loginPage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter correct confirm password!");
            }    
            

        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            
            LoginForm loginPage = new LoginForm();
            this.Hide();
            loginPage.ShowDialog();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}