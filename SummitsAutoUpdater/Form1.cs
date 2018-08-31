using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

/* Simple Microsoft .Net (C#) Auto Updater for your applications
 * Created By: Summit
 * Developers Links: https://www.instagram.com/Desecrative  https://www.youtube.com/SayMods
 * Github: https://www.github.com/Summiit
 * Created Date: 8/30/2018 
 * Please give credit if you use this code
 * This Updater uses pastebin to check for updates, It reads the raw page on pastebin and checks the version number if the
 * version number is different it downloads the update 
 * Youre Pastebin should look like this https://pastebin.com/5uvLSSRL 
 * To Use Add the DownloadFile and CheckforUpdate classes along with the version string and weburl string to your program
 * Then add CheckForUpdate(); in your InitializeComponent on your main form so it checks for updates on load. */

namespace SummitsAutoUpdater
{
    public partial class Form1 : Form
    {
        public static string version = "1.0"; //Version number. Must match number on pastebin if no update
        public static string weburl = "pastebin raw url here Example: pastebin.com/raw/5uvLSSRL"; // URL to Download from Dont forget your https
        public Form1()
        {
            InitializeComponent();
            CheckForUpdate();
        }

        public static void DownloadFile(string website, string name) //Code to auto download
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(website, "" + Application.StartupPath + @"\Downloads\" + name);
        }

        public static void CheckForUpdate()
        {
            string[] lines = new WebClient().DownloadString(weburl).Split("\n".ToCharArray());
            if (!lines[0].Contains(version))
            {
                MessageBox.Show("Update Found! Update will download to the application folder and then will close.", "New Update Available");
                WebClient webClient = new WebClient();
                webClient.DownloadFile(lines[1], "" + Application.StartupPath + @"\Rar file name here Example: MyProgramName.rar"); //Used for autodownloading requires direct download link. Sendspace and github work
                //Process.Start(lines[1]); //If you want it to open to the page with the download instead of autoupdating uncomment this line and comment out line 46
                Environment.Exit(0);
            }
        }
    }
}
