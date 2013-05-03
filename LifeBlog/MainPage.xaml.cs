using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LifeBlog.Resources;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LifeBlog
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private string LoginUrl = "http://lifeblog.herokuapp.com/api-root/api-token-auth/";
        
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void Forgetpass_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void postComplete(object sender, UploadStringCompletedEventArgs e)
        {
            try {
                string result = e.Result;
                int begin = result.IndexOf("token");
                int end = result.IndexOf("}");
                string token = result.Substring(begin + 9, end - begin-10);
                userManage.User user = new userManage.User();
                user.token = token;
                this.NavigationService.Navigate(new Uri("/userManage/success.xaml", UriKind.Relative));
            }catch(Exception){
                hind.Text = "wrong username or password";
            }
            

        }

        private string getPostdata()
        {
            string result = "username="+userName.Text+"&"+"password="+password.Password;
            return result;
        }

        private void select_connection_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void LoginIn_Click_1(object sender, RoutedEventArgs e)
        {
            hind.Text = "";
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            var uri = new Uri(LoginUrl,UriKind.Absolute);
            string postData = getPostdata();         
            webClient.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
            webClient.AllowWriteStreamBuffering = true;
            webClient.Encoding = System.Text.Encoding.UTF8;
            webClient.UploadStringAsync(uri, "POST", postData.ToString());
            webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(postComplete);
       
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/userManage/Register.xaml", UriKind.Relative));
        }
    }
}