using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.EditContextMenu
{
    /// <summary>
    /// <see cref="DeleteMenuItem"/> holds the <see cref="DeleteAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    internal class DeleteMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="DeleteMenuItem"/> instance.
        /// </summary>
        /// <seealso cref="UMLMenuItem()"/>
        internal DeleteMenuItem()
        {
            Text = "Delete";
        }

        /// <summary>
        /// Generates a <see cref="DeleteMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        internal DeleteMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="DeleteMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        internal DeleteMenuItem(string text, UMLAction action) : base(text, action)
        {

        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.TrashIcon;
        }
    }
}
