using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents
{
    /// <summary>
    /// This <code>class</code> acts as a menu bar item of UML Editor, holding
    /// a corresponding <see cref="UMLAction"/> to be triggered when menu item
    /// is clicked.
    /// </summary>
    public class UMLMenuItem : ToolStripMenuItem
    {
        /// <summary>
        /// Holds the drak theme color used by MetroModernUI.
        /// </summary>
        private static readonly Color _metroDarkThemeColor = Color.FromArgb(19, 19, 19);

        /// <summary>
        /// Holds the corresponding <see cref="UMLAction"/> to be triggered.
        /// </summary>
        private UMLAction _action;

        /// <summary>
        /// Generates an <see cref="UMLMenuItem"/> instance.
        /// </summary>
        public UMLMenuItem()
        {
            ThemeInit();
            IconInit();
        }

        /// <summary>
        /// Generates an <see cref="UMLMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <param name="text">The item text to be displayed on menu item.</param>
        public UMLMenuItem(string text) : base(text)
        {
            ThemeInit();
            IconInit();
        }

        /// <summary>
        /// Generates an <see cref="UMLMenuItem"/> instance with action initialized.
        /// </summary>
        /// <param name="action">The action to be triggered when item clicked.</param>
        public UMLMenuItem(UMLAction action)
        {
            ActionInit(action);
            ThemeInit();
            IconInit();
        }

        /// <summary>
        /// Generates an <see cref="UMLMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <param name="text">The item text to be displayed on menu item.</param>
        /// <param name="action">The action to be triggered when item clicked.</param>
        public UMLMenuItem(string text, UMLAction action) : base(text)
        {
            ActionInit(action);
            ThemeInit();
            IconInit();
        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected virtual void IconInit()
        {

        }

        /// <summary>
        /// Handler fired when menu item clicked.
        /// Triggers the helding action.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> that fires this event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> that contains information of event.
        /// </param>
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            Debug.Assert(_action != null);
            _action.Trigger();
        }

        /// <summary>
        /// Initializes the <see cref="UMLAction"/> held by this menu item.
        /// </summary>
        /// <param name="action">
        /// The corresponding <see cref="UMLAction"/> this item should hold.
        /// </param>
        private void ActionInit(UMLAction action)
        {
            Debug.Assert(action != null);
            _action = action;
            Click += OnMenuItemClick;
        }

        /// <summary>
        /// Initializes the style of menu item.
        /// </summary>
        private void ThemeInit()
        {
            ForeColor = Color.White;
            BackColor = _metroDarkThemeColor;
        }
    }
}
