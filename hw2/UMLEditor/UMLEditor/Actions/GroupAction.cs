using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;

namespace UMLEditor.Actions
{
    /// <summary>
    /// An <see cref="UMLAction"/> which performs the group operation.
    /// </summary>
    /// <seealso cref="UMLAction"/>
    internal class GroupAction : UMLAction
    {
        /// <summary>
        /// Generates an <see cref="GroupAction"/> instance.
        /// </summary>
        /// <seealso cref="UMLAction()"/>
        internal GroupAction()
        {
            
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Groups all selected <see cref="Shape"/>s into a newly created
        /// <see cref="CompositionObject"/>.
        /// </summary>
        /// <seealso cref="UMLAction.Trigger()"/>
        public override void Trigger()
        {
            Shape[] selectedShapes = Canvas.SelectedShapes;

            if (selectedShapes.Length < 2)
            {
                MessageBox.Show("Please select 2 or more object for grouping", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CompositionObject compositionObject = GroupShapes(selectedShapes);
            Canvas.AddShape(compositionObject);
            compositionObject.IsSelected = true;
            Canvas.Invalidate();

            base.Trigger();
        }

        /// <summary>
        /// Groups all given <see cref="Shape"/>s and gets the grouped
        /// <see cref="CompositionObject"/>.
        /// </summary>
        /// <param name="shapes"><see cref="Shape"/>s to be grouped.</param>
        /// <returns>Returns the grouped <see cref="CompositionObject"/></returns>
        private CompositionObject GroupShapes(Shape[] shapes)
        {
            CompositionObject compositionObject = new CompositionObject();

            foreach (Shape shape in shapes)
            {
                if (shape is BasicObject)
                {
                    Canvas.RemoveShape(shape);
                    compositionObject.Add(shape);
                }
            }

            compositionObject.UpdateSize();
            return compositionObject;
        }
    }
}
