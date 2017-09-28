using PoeHUD.Framework;
using PoeHUD.Plugins;
using PoeHUD.Poe.Components;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AutoQuit
{
    class AutoQuitCore : BaseSettingsPlugin<AutoQuitSettings>
    {
        private readonly int errmsg_time = 10;

        public override void Initialise()
        {
            PluginName = "AutoQuit";
            base.Initialise();
        }

        public override void Render()
        {
            base.Render();

            // Panic Quit Key.
            if (WinApi.IsKeyDown(Settings.forcedAutoQuit))
                PoeProcessHandler.ExitPoe("cports.exe", "/close * * * * " + GameController.Window.Process.ProcessName + ".exe");

            var LocalPlayer = GameController.Game.IngameState.Data.LocalPlayer;
            var PlayerHealth = LocalPlayer.GetComponent<Life>();
            if (Settings.Enable && LocalPlayer.IsValid)
            {
                if (Math.Round(PlayerHealth.HPPercentage, 3) * 100 < (Settings.percentHPQuit.Value))
                {
                    try
                    {
                        PoeProcessHandler.ExitPoe("cports.exe", "/close * * * * " + GameController.Window.Process.ProcessName + ".exe");
                    }
                    catch (Exception)
                    {
                        LogError("Error: Cannot find cports.exe, you must die now!", errmsg_time);
                    }
                }
                if (PlayerHealth.MaxES > 0 && (Math.Round(PlayerHealth.ESPercentage, 3) * 100 < (Settings.percentESQuit.Value)))
                {
                    try
                    {
                        PoeProcessHandler.ExitPoe("cports.exe", "/close * * * * " + GameController.Window.Process.ProcessName + ".exe");
                    }
                    catch (Exception)
                    {
                        LogError("Error: Cannot find cports.exe, you must die now!", errmsg_time);
                    }
                }
            }

            if (Settings.fps.Value > 0)
            {
                Thread.Sleep(1000/Settings.fps.Value);
            }
            return;
        }
    }
}
