using KeyboardTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

public static class GitUpdater
{
    public static string ThisVersion { get; } = "0.9.8.1"; //TODO: Before commiting change version here and in file "version_info"
    private static readonly string linkForNewVersion = "https://github.com/tavvi1337/KeyboardTraining/blob/master/version_info";
    private static readonly string linkForDownloadFile = "https://github.com/tavvi1337/KeyboardTraining/raw/master/KeyboardTrainer/bin/Debug/KeyboardTrainer.exe";
    private static readonly string programName = "KeyboardTrainer";

    public static bool NeedUpdate()
    {
        string newVersion = GetNewVersion();
        return (newVersion == ThisVersion) ? false : true;
    }
    public static void Update()
    {
        string newVersion = GetNewVersion();
        if (newVersion != ThisVersion)
        {
            string fileName = DownloadFile();

            ReplaceFiles($"{Environment.CurrentDirectory}\\{fileName}");
        }
    }

    private static void ReplaceFiles(string newFileFullPath)
    {
        Process.Start(newFileFullPath);
        ProcessStartInfo Info = new ProcessStartInfo
        {
            Arguments = "/C choice /C Y /N /D Y /T 10 & Del " + Assembly.GetExecutingAssembly().Location,//wait 10 sec, self delete 
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            FileName = "cmd"
        };
        Process.Start(Info);

        UserProgressSaver.Config.SayAboutUpdate = true;
        UserProgressSaver.SaveProgress();

        Environment.Exit(0);
    }

    /// <summary>
    /// Download file, returns filename
    /// </summary>
    /// <returns></returns>
    private static string DownloadFile()
    {
        WebClient wc = new WebClient();
        wc.Headers["User-Agent"] = "Mozilla/4.0";
        wc.Encoding = Encoding.UTF8;

        if (!File.Exists($"{programName}.exe"))
        {
            wc.DownloadFile(linkForDownloadFile, $"{programName}.exe");
            return $"{programName}.exe";
        }
        else
        {

            int counter = 1;
            while (true)
            {
                if (!File.Exists($"{programName}({counter}).exe"))
                {
                    try
                    {
                        wc.DownloadFile(linkForDownloadFile, $"{programName}({counter}).exe");
                    }
                    catch
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//for win 7

                        wc.DownloadFile(linkForDownloadFile, $"{programName}({counter}).exe");
                    }

                    return $"{programName}({counter}).exe";
                }
                counter++;
            }
        }
    }

    private static string GetNewVersion()
    {
        WebClient wc = new WebClient();
        wc.Headers["User-Agent"] = "Mozilla/4.0";
        wc.Encoding = Encoding.UTF8;

        string html;
        try
        {
            html = wc.DownloadString(linkForNewVersion);
        }
        catch
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;//for win 7

            html = wc.DownloadString(linkForNewVersion);
        }

        //get string array of coincidence: <title>Hello</title> - returns Hello
        //<td id="LC1" class="blob-code blob-code-inner js-file-line">0.1</td> - returns version
        string[] str = ParseMethod("<td id=\"LC1\" class=\"blob-code blob-code-inner js-file-line\">", "</td>", html);
        return str[0];
    }
    private static string[] ParseMethod(string str_begin, string str_end, string str_html)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < str_html.Length - str_begin.Length; i++)
        {
            if (str_html.Substring(i, str_begin.Length) == str_begin)
            {
                int start = i + str_begin.Length;
                for (int j = start; j < str_html.Length - str_end.Length; j++)
                {
                    if (str_html.Substring(j, str_end.Length) == str_end)
                    {
                        int finish = j;
                        list.Add(str_html.Substring(start, finish - start));
                        break;
                    }
                }
            }
        }
        return list.ToArray();
    }
}