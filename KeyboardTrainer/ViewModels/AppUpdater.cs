﻿using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KeyboardTrainer.Models
{
    class AppUpdater
    {
        public static bool NeedUpdate => GitUpdater.NeedUpdate();
        /// <summary>
        /// Finds new version, asks user, update, restart app
        /// </summary>
        public static void Update(bool silence)
        {
            Task checkNewVersion = new Task(() =>
            {
                Thread.Sleep(1000);
                bool sayAboutFail = false;
                try
                {
                    if (GitUpdater.NeedUpdate())
                    {
                        MessageBoxResult res = MessageBoxResult.No;
                        if (!silence)
                        {
                            if (UserProgressSaver.Config.SayAboutUpdate)
                            {
                                res = SilenceMessageBox.Show(Loc.Translate("New update found! Do you want to update now?"), "KeyboardTrainer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            }
                            if (res == MessageBoxResult.No)
                            {
                                UserProgressSaver.Config.SayAboutUpdate = false;
                                return;
                            }
                        }
                        else
                        {
                            res = SilenceMessageBox.Show(Loc.Translate("New update found! Do you want to update now?"), "KeyboardTrainer", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        }
                        if (res == MessageBoxResult.Yes)
                        {
                            sayAboutFail = true;
                            GitUpdater.Update();
                        }
                    }
                }
                catch
                {
                    if (sayAboutFail)
                    {
                        SilenceMessageBox.Show(Loc.Translate("Update error"), Loc.Translate("Updater"), MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
            checkNewVersion.Start();
        }
    }
}
