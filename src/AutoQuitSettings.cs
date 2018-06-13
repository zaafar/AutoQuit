using PoeHUD.Hud.Settings;
using PoeHUD.Plugins;

namespace AutoQuit
{
    class AutoQuitSettings : SettingsBase
    {
        public AutoQuitSettings()
        {
            percentHPQuit = new RangeNode<float>(35f, 0f, 100f);
            percentESQuit = new RangeNode<float>(35f, 0, 100);
            forcedAutoQuit = System.Windows.Forms.Keys.F4;
        }

        #region Auto Quit Menu
        [Menu("Select key for Forced Quit", 1)]
        public HotkeyNode forcedAutoQuit { get; set; }
        [Menu("Min % Life to Auto Quit", 2)]
        public RangeNode<float> percentHPQuit { get; set; }
        [Menu("Min % ES Auto Quit", 3)]
        public RangeNode<float> percentESQuit { get; set; }
        [Menu("Quit if HP flasks are empty", 4)]
        public ToggleNode emptyHPFlasks { get; set; } = false;
        #endregion
    }
}
