using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.FileContextMenu
{
    /// <summary>
    /// <see cref="FileContextMenu"/> holds all <see cref="UMLMenuItem"/>s
    /// relative to file operations.
    /// </summary>
    internal sealed class FileContextMenu : UMLContextMenu
    {
        /// <summary>
        /// Generates a <see cref="FileContextMenu"/> instance.
        /// </summary>
        internal FileContextMenu()
        {
            Items.Add(new FileMenuItem("New file", new NewFileAction()));
            Items.Add(new ExitMenuItem("Exit", new ExitAction()));
        }
    }
}
