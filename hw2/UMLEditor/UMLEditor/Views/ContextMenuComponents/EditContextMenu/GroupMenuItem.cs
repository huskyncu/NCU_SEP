using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.EditContextMenu
{
    /// <summary>
    /// <see cref="GroupMenuItem"/> holds the <see cref="GroupAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    internal class GroupMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="GroupMenuItem"/> instance.
        /// </summary>
        /// <seealso cref="UMLMenuItem()"/>
        internal GroupMenuItem()
        {
            
        }

        /// <summary>
        /// Generates a <see cref="GroupMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        internal GroupMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="GroupMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        internal GroupMenuItem(string text, UMLAction action) : base(text, action)
        {

        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.GroupIcon;
        }
    }
}
