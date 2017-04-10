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
        }

        #region Auto Quit Menu
        [Menu("Press F4 for Forced Quit", 1)]
        public EmptyNode emptynode { get; set; }
        [Menu("Min % Life to Auto Quit", 2)]
        public RangeNode<float> percentHPQuit { get; set; }
        [Menu("Min % ES Auto Quit", 3)]
        public RangeNode<float> percentESQuit { get; set; }
        #endregion
    }
}
