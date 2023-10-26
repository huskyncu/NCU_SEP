using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Views.Dialogs;

namespace UMLEditor.Actions
{
    /// <summary>
    /// An <see cref="UMLAction"/> which performs the rename
    /// <see cref="Shape"/> operation.
    /// </summary>
    /// <seealso cref="UMLAction"/>
    internal class RenameAction : UMLAction
    {
        /// <summary>
        /// Generates an <see cref="RenameAction"/> instance.
        /// </summary>
        /// <seealso cref="UMLAction()"/>
        internal RenameAction()
        {
            
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Renames all selected <see cref="Shape"/>s on the
        /// <see cref="Views.Canvas"/>.
        /// </summary>
        /// <seealso cref="UMLAction.Trigger()"/>
        public override void Trigger()
        {
            Shape[] selectedShapes = Canvas.SelectedShapes;

            if (selectedShapes.Length == 0)
            {
                MessageBox.Show("No object selected!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RenameDialog dialog = new RenameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.ObjectName;
                RenameShapes(selectedShapes, name);

                Canvas.Invalidate();
            }
        }

        /// <summary>
        /// Rename all given <see cref="Shape"/>s to the given name.
        /// </summary>
        /// <param name="shapes">The <see cref="Shape"/>s to be renamed.</param>
        /// <param name="name">The new name of all given <see cref="Shape"/>s.</param>
        private void RenameShapes(Shape[] shapes, string name)
        {
            foreach (Shape shape in shapes)
            {
                shape.Name = name;
            }
        }
    }
}
