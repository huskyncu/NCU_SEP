using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.EditContextMenu
{
    /// <summary>
    /// <see cref="UnGroupMenuItem"/> holds the <see cref="UngroupAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    internal class UnGroupMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="UnGroupMenuItem"/> instance.
        /// </summary>
        /// <seealso cref="UMLMenuItem()"/>
        internal UnGroupMenuItem()
        {
            
        }

        /// <summary>
        /// Generates a <see cref="UnGroupMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        internal UnGroupMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="UnGroupMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        internal UnGroupMenuItem(string text, UMLAction action) : base(text, action)
        {

        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.UngroupIcon;
        }
    }
}
