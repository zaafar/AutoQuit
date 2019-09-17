using System.Windows.Forms;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace AutoQuit
{
    class AutoQuitSettings : ISettings
    {
        public AutoQuitSettings()
        {
            Enable = new ToggleNode(false);
            percentHPQuit = new RangeNode<float>(35f, 0f, 100f);
            percentESQuit = new RangeNode<float>(35f, 0f, 100f);
            forcedAutoQuit = Keys.F4;
            emptyHPFlasks = new ToggleNode(false);
        }
        
        public ToggleNode Enable { get; set; }

        #region Auto Quit Menu
        //[Menu("Select key for Forced Quit", 1)]
        public HotkeyNode forcedAutoQuit { get; set; }
        //[Menu("Min % Life to Auto Quit", 2)]
        public RangeNode<float> percentHPQuit { get; set; }
        //[Menu("Min % ES Auto Quit", 3)]
        public RangeNode<float> percentESQuit { get; set; }
        //[Menu("Quit if HP flasks are empty", 4)]
        public ToggleNode emptyHPFlasks { get; set; }
        #endregion
    }
}
