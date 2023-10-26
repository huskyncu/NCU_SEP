using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.EditContextMenu
{
    /// <summary>
    /// <see cref="RenameMenuItem"/> holds the <see cref="RenameAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    public class RenameMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="RenameMenuItem"/> instance.
        /// </summary>
        /// <seealso cref="UMLMenuItem()"/>
        public RenameMenuItem()
        {
            Text = "Rename";
        }

        /// <summary>
        /// Generates a <see cref="RenameMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        public RenameMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="RenameMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        public RenameMenuItem(string text, UMLAction action) : base(text, action)
        {
            
        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.EditIcon;
        }
    }
}
