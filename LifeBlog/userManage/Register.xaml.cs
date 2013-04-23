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
namespace LifeBlog
{
    public partial class Register : PhoneApplicationPage
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private HttpWebRequest request;
        private string RegisterUrl = "http://lifeblog.herokuapp.com/api-root/users/";
        public Register()
        {
            InitializeComponent();
        }

        private void Regist_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
             
            request = (HttpWebRequest)WebRequest.Create(RegisterUrl);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            IAsyncResult r = request.BeginGetRequestStream(new AsyncCallback(readRequest), request);
            allDone.WaitOne();

            IAsyncResult responseR = request.BeginGetResponse(new AsyncCallback(getResponse), request);
            allDone.WaitOne();
        }

        private void getResponse(IAsyncResult ar)
        {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
            WebResponse Response = request.EndGetResponse(ar);
           
            Stream response = Response.GetResponseStream();
            StreamReader streamRead = new StreamReader(response);           
            Char[] readBuff = new Char[256];
            int count = streamRead.Read(readBuff, 0, 256);
          
            while (count > 0)
            {
                String outputData = new String(readBuff, 0, count);
                JsonReader reader = new JsonTextReader(new StringReader(outputData));             
                Console.WriteLine(reader.Value);
                count = streamRead.Read(readBuff, 0, 256);
                
            }

            // Close the Stream Object.
            Response.Close();
            response.Close();
            streamRead.Close();
            allDone.Set();


        }

        private void readRequest(IAsyncResult ar)
        {
            HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
            Stream streamResponse = request.EndGetRequestStream(ar);
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);
            writer.WriteStartObject();
            writer.WritePropertyName("username");
            writer.WriteValue(UserID.Text);
            writer.WritePropertyName("password");
            writer.WriteValue(pass.Text);
            writer.WritePropertyName("date_of_birth");
            writer.WriteValue(datepicker.Value);
            writer.WritePropertyName("email");
            writer.WriteValue(email.Text);
            writer.WritePropertyName("first_name");
            writer.WriteValue(first_name.Text);
            writer.WritePropertyName("last_name");
            writer.WriteValue(last_name.Text);
            writer.WriteEndObject();
            string jsonText = sw.GetStringBuilder().ToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonText);
            streamResponse.Write(byteArray,0,jsonText.Length);
            writer.Close();
            streamResponse.Close();
            allDone.Set();
        }
    }
}