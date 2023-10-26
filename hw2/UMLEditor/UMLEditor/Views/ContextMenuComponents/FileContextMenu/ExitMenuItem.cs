using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.FileContextMenu
{
    /// <summary>
    /// <see cref="ExitMenuItem"/> holds the <see cref="ExitAction"/>, triggering
    /// this action when clicked.
    /// </summary>
    /// <seealso cref="UMLMenuItem"/>
    internal class ExitMenuItem : UMLMenuItem
    {
        /// <summary>
        /// Generates a <see cref="ExitMenuItem"/> instance.
        /// </summary>
        /// /// <seealso cref="UMLMenuItem()"/>
        internal ExitMenuItem()
        {
            Text = "Exit";
        }

        /// <summary>
        /// Generates a <see cref="ExitMenuItem"/> instance with item text initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string)"/>
        internal ExitMenuItem(string text) : base(text)
        {
            
        }

        /// <summary>
        /// Generates a <see cref="ExitMenuItem"/> instance with item text and
        /// action initialized.
        /// </summary>
        /// <seealso cref="UMLMenuItem(string, UMLAction)"/>
        internal ExitMenuItem(string text, UMLAction action) : base(text, action)
        {

        }

        /// <summary>
        /// Initializes the icon.
        /// </summary>
        protected override void IconInit()
        {
            Image = Properties.Resources.CloseIcon;
        }
    }
}
