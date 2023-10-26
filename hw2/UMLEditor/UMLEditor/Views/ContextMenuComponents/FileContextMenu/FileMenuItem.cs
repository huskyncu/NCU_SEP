using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.FileContextMenu
{
    /// <summary>
    /// <see cref="FileMenuItem"/> holds the <see cref="NewFileAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    internal class FileMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="FileMenuItem"/> instance.
        /// </summary>
        /// <seealso cref="UMLMenuItem()"/>
        internal FileMenuItem()
        {
            Text = "New file";
        }

        /// <summary>
        /// Generates a <see cref="FileMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        internal FileMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="FileMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        internal FileMenuItem(string text, UMLAction action) : base(text, action)
        {
            
        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.FileIcon;
        }
    }
}
