using UMLEditor.Actions;

namespace UMLEditor.Views.ContextMenuComponents.EditContextMenu
{
    /// <summary>
    /// <see cref="EditContextMenu"/> holds all <see cref="UMLMenuItem"/>s
    /// relative to file operations.
    /// </summary>
    internal sealed class EditContextMenu : UMLContextMenu
    {
        /// <summary>
        /// Generates a <see cref="EditContextMenu"/> instance.
        /// </summary>
        internal EditContextMenu()
        {
            Items.Add(new RenameMenuItem("Rename", new RenameAction()));
            Items.Add(new GroupMenuItem("Group", new GroupAction()));
            Items.Add(new UnGroupMenuItem("Ungroup", new UngroupAction()));
            Items.Add(new DeleteMenuItem("Delete", new DeleteAction()));
        }
    }
}
