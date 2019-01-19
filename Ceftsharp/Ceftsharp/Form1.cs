using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
namespace Ceftsharp
{
    /// <summary>
    /// Berk ARAT
    /// berkarat.com Cefsharp Uygulama
    /// </summary>

    public partial class Form1 : Form
    {
        public static string cmd = string.Empty;
        public static ChromiumWebBrowser chrome;
        public static string path = "http://localhost/";
        public static bool passwordistrue = false;
        public static string page = string.Empty;
        public static string password = string.Empty;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            CefSettings settings = new CefSettings();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            Cef.Initialize(settings);
            string url = "http://localhost/mainpage.html";
            chrome = new ChromiumWebBrowser(url);
            chrome.StatusMessage += Chrome_StatusMessage;
            chrome.IsBrowserInitializedChanged += Chrome_IsBrowserInitializedChanged;
            chrome.FrameLoadStart += Chrome_FrameLoadStart;
            chrome.FrameLoadEnd += Chrome_FrameLoadEnd;

            chrome.LoadingStateChanged += Chrome_LoadingStateChanged;
            chrome.RegisterJsObject("object", new CallbackObjectForJs());
            this.panel1.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
        }

        private void Chrome_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                // sayfa yüklendi

                switch (page)
                {
                    case "last":

                        if (passwordistrue)
                        {
                            // password true

                           

                            chrome.ExecuteScriptAsync(" window.onload(writepassword('"+ password + "'));");

                        }
                        else
                        {
                            chrome.ExecuteScriptAsync(" window.onload(writewrong('WRONG PASSWORD'));");

                        }
                        page = string.Empty;


                        break;
                }

            }

        }

        private void Chrome_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            string gidilecek_url = e.Url;
        }
        private void Chrome_StatusMessage(object sender, StatusMessageEventArgs e)
        {
        }
        private void Chrome_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (!e.IsBrowserInitialized)
            {
                MessageBox.Show("BROWSER NOT INITIALIZED");
            }
        }
        private void Chrome_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {// load edildi
            string bulundugu = e.Url;
            int statuscode = e.HttpStatusCode; // 404 notfound error 0 

            if (cmd == "keypad")
            {
                chrome.ExecuteScriptAsync("yaz('" + cmd + "');"); // SCRIPT CAGIRDIK ! 
            }
            if (statuscode == 404 || statuscode == 0)
            {

                chrome.Load(path+"mainpage.html");
                chrome.ExecuteScriptAsync("alert('Page Not Found !!');");

            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();

        }

        public class CallbackObjectForJs
        {
        
            public void getpage(string pageurl)

            {
                chrome.Load(path+pageurl);

            }



            public void message(string msg)
            {
                cmd = msg;
                //MessageBox.Show(msg);
                // MESAJ ALINIR !
            }
            public void go_lastscreen(Array message)
            {
                string[] arr = new string[message.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    arr[i] =     message.GetValue(i).ToString();
                    
                }

                if (arr[0]=="1234")
                {
                    chrome.Load(path+arr[1].ToString());
                    password = arr[0];
                    passwordistrue = true;
                }
                else
                {
                    //chrome.ExecuteScriptAsync("alert('Hatalı Şifre')");
                    passwordistrue = false;
                    chrome.Load(path+arr[1].ToString());

                }
                page = "last";

            }

        }

    }

}








