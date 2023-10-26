using System.Drawing;
using System.Windows.Forms;

namespace UMLEditor.Views.ContextMenuComponents
{
    /// <summary>
    /// <see cref="UMLContextMenu"/> gives the MetroModernUI style look of
    /// context menu GUI.
    /// </summary>
    public class UMLContextMenu : ToolStripDropDownMenu
    {
        /// <summary>
        /// Holds the drak theme color used by MetroModernUI.
        /// </summary>
        private static readonly Color _metroDarkThemeColor = Color.FromArgb(19, 19, 19);

        /// <summary>
        /// Holds the image margin color which looks comfortable with the dark
        /// theme color of MetroModernUI.
        /// </summary>
        private static readonly Color _metroDarkThemeImageMarginColor = Color.FromArgb(35, 35, 35);

        /// <summary>
        /// Generates an <see cref="UMLContextMenu"/> instance.
        /// </summary>
        public UMLContextMenu()
        {
            ShowImageMargin = true;
            BackColor = _metroDarkThemeColor;
            ForeColor = Color.White;
            Renderer = new UMLMenuRenderer();
        }

        /// <summary>
        /// Customized renderer for <see cref="UMLContextMenu"/>.
        /// </summary>
        private class UMLMenuRenderer : ToolStripProfessionalRenderer
        {
            public UMLMenuRenderer() : base(new UMLMenuColors()) { }
        }

        /// <summary>
        /// Customized color for <see cref="UMLContextMenu"/>.
        /// </summary>
        private class UMLMenuColors : ProfessionalColorTable
        {
            private static readonly Color _metroDarkThemeColor = Color.FromArgb(19, 19, 19);

            public override Color MenuItemSelected
            {
                get { return Color.Gray; }
            }

            public override Color MenuBorder
            {
                get { return Color.DarkGray; }
            }

            public override Color MenuItemBorder
            {
                get { return Color.Transparent; }
            }

            public override Color ToolStripBorder
            {
                get { return _metroDarkThemeColor; }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return _metroDarkThemeColor; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return _metroDarkThemeImageMarginColor; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return _metroDarkThemeImageMarginColor; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return _metroDarkThemeImageMarginColor; }
            }
        }
    }
}
