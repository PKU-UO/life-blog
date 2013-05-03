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
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace LifeBlog
{
    public partial class Register : PhoneApplicationPage
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        //private HttpWebRequest request;
        
        private string RegisterUrl = "http://lifeblog.herokuapp.com/api-root/users/";
        public Register()
        {
            InitializeComponent();
        }


       
        private void postComplete(object sender, UploadStringCompletedEventArgs e)
        {
            string res = e.Result;
            NavigationService.Navigate(new Uri("/userManage/success.xaml", UriKind.Relative));
        }
        private string getPostdata()
        {
            LifeBlog.userManage.User user = new LifeBlog.userManage.User();
            user.username = UserName.Text;
            user.password = password.Password;
            user.date_of_birth = datepicker.ValueString;
            user.email = email.Text;
            user.first_name = first_name.Text;
            user.last_name = last_name.Text;
            
            string result = JsonConvert.SerializeObject(user);
            //StringWriter sw = new StringWriter();
            //JsonWriter writer = new JsonTextWriter(sw);
            //writer.WriteStartObject();
            //writer.WritePropertyName("username");
            //writer.WriteValue(UserID.Text);
            //writer.WritePropertyName("password");
            //writer.WriteValue(pass.Text);
            //writer.WritePropertyName("date_of_birth");
            //writer.WriteValue(datepicker.Value);
            //writer.WritePropertyName("email");
            //writer.WriteValue(email.Text);
            //writer.WritePropertyName("first_name");
            //writer.WriteValue(first_name.Text);
            //writer.WritePropertyName("last_name");
            //writer.WriteValue(last_name.Text);
            //writer.WriteEndObject();
            //string jsonText = sw.GetStringBuilder().ToString();
            return result;
        }

        private  void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            var uri = new Uri(RegisterUrl, UriKind.Absolute);
            string postData = getPostdata();
            webClient.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
            webClient.AllowWriteStreamBuffering = true;
            webClient.Encoding = System.Text.Encoding.UTF8;
            webClient.UploadStringAsync(uri, "POST", postData.ToString());
            webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(postComplete);
            //allDone.WaitOne();
        }
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(RegisterUrl);
        //    httpWebRequest.ContentType = "text/json";
        //    httpWebRequest.AllowWriteStreamBuffering = true;
        //    httpWebRequest.Method = "POST";
        //     //Write the request Asynchronously 
        //    try {
        //        using (var stream = await Task.Factory.FromAsync<Stream>(httpWebRequest.BeginGetRequestStream,
        //                                                            httpWebRequest.EndGetRequestStream, null))
        //        {
        ////            create some json string
        //            string json = getPostdata();

        //             //convert json to byte array
        //            byte[] jsonAsBytes = Encoding.UTF8.GetBytes(json);

        //             //Write the bytes to the stream
        //            await stream.WriteAsync(jsonAsBytes, 0, jsonAsBytes.Length);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message); 
        //   }
        //}
        //private void getResponse(IAsyncResult ar)
        //{
        //HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
        //WebResponse Response = request.EndGetResponse(ar);

        //Stream response = Response.GetResponseStream();
        //StreamReader streamRead = new StreamReader(response);           
        //Char[] readBuff = new Char[256];
        //int count = streamRead.Read(readBuff, 0, 256);

        //while (count > 0)
        //{
        //    String outputData = new String(readBuff, 0, count);
        //    JsonReader reader = new JsonTextReader(new StringReader(outputData));             
        //    Console.WriteLine(reader.Value);
        //    count = streamRead.Read(readBuff, 0, 256);

        //}

        //// Close the Stream Object.
        //Response.Close();
        //response.Close();
        //streamRead.Close();
        //allDone.Set();


        //}

        //    private void readRequest(IAsyncResult ar)
        //    {
        //        HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
        //        Stream streamResponse = request.EndGetRequestStream(ar);
        //        StringWriter sw = new StringWriter();
        //        JsonWriter writer = new JsonTextWriter(sw);
        //        writer.WriteStartObject();
        //        writer.WritePropertyName("username");
        //        writer.WriteValue(UserID.Text);
        //        writer.WritePropertyName("password");
        //        writer.WriteValue(pass.Text);
        //        writer.WritePropertyName("date_of_birth");
        //        writer.WriteValue(datepicker.Value);
        //        writer.WritePropertyName("email");
        //        writer.WriteValue(email.Text);
        //        writer.WritePropertyName("first_name");
        //        writer.WriteValue(first_name.Text);
        //        writer.WritePropertyName("last_name");
        //        writer.WriteValue(last_name.Text);
        //        writer.WriteEndObject();
        //        string jsonText = sw.GetStringBuilder().ToString();
        //        byte[] byteArray = Encoding.UTF8.GetBytes(jsonText);
        //        streamResponse.Write(byteArray,0,jsonText.Length);
        //        writer.Close();
        //        streamResponse.Close();
        //        allDone.Set();
        //    }
        //}
    }
}