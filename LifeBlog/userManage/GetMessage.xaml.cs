using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Xml;
using System.Threading;



namespace LifeBlog.userManage
{
    public partial class Get : PhoneApplicationPage
    {
        //public static ManualResetEvent allFinish=new ManualResetEvent(false);
        
       // private string GetUrl="http://lifeblog.herokuapp.com/api-root/articles";
        private void PhoneApplicationPage_loaded(object sender, RoutedEventArgs e) 
        {
            DoWebClient();

        }
 
        public Get()
        {
            InitializeComponent();
        }
        private void getComplete(object sender, UploadStringCompletedEventArgs e) 
        {
            string res = e.Result;
            NavigationService.Navigate(new Uri("/userManger/success.xaml", UriKind.Relative));
        }


        private void DoWebClient()
        {
            WebClient webClient = new WebClient();
            webClient.OpenReadAsync(new Uri("http://lifeblog.herokuapp.com/api-root/articles"));
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
        }

        private void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            using (StreamReader reader = new StreamReader(e.Result))
            {
                string contents = reader.ReadToEnd();
                int begin = contents.ToString().IndexOf("body");
                int end = contents.ToString().IndexOf("");
                outputBox.Text = contents.ToString().Substring(begin, end);
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        

        
    }
    
}