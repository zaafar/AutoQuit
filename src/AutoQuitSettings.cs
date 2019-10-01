using System.Windows.Forms;
using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace AutoQuit
{
    class AutoQuitSettings : ISettings
    {
        public AutoQuitSettings()
        {
            Enable = new ToggleNode(false);
            flasksTitle = new EmptyNode();
            emptyHPFlasks = new RangeNode<int>(0, 0, 2);
            percentHPQuit = new RangeNode<float>(35f, 0f, 100f);
            percentESQuit = new RangeNode<float>(35f, 0f, 100f);
            forcedAutoQuit = Keys.F4;
            suspend = new ToggleNode(true);
        }
        
        public ToggleNode Enable { get; set; }

        #region Auto Quit Menu
        [Menu("Forced Quit Hotkey:", 10)]
        public HotkeyNode forcedAutoQuit { get; set; }
        [Menu("Quit if HP flasks are empty", "0 - Disable\n1 - Enable\n2 - Only when HP/ES min values was reached" +
            "\n\n[WARNING]" +
            "\nPlease note that mode #2 will not allow you to quit if you have got at least one non-empty life flask.", 20)]
        public EmptyNode flasksTitle { get; set; }
        [Menu("Select mode", 22, 20)]
        public RangeNode<int> emptyHPFlasks { get; set; }
        [Menu("Min % Life to Auto Quit", 30)]
        public RangeNode<float> percentHPQuit { get; set; }
        [Menu("Min % ES Auto Quit", 40)]
        public RangeNode<float> percentESQuit { get; set; }
        [Menu("Suspend in Hideout", "Suspended in Town by default.\nForce quit with the hotkey works anyway.", 50)]
        public ToggleNode suspend { get; set; }
        #endregion
    }
}
