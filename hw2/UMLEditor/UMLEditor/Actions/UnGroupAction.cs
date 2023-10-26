using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Views;

namespace UMLEditor.Actions
{
    /// <summary>
    /// An <see cref="UMLAction"/> which performs the ungroup operation to
    /// selected <see cref="CompositionObject"/>.
    /// </summary>
    /// <seealso cref="UMLAction"/>
    internal class UngroupAction : UMLAction
    {
        /// <summary>
        /// Generates an <see cref="UngroupAction"/> instance.
        /// </summary>
        /// <seealso cref="UMLAction()"/>
        internal UngroupAction()
        {
            
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Ungroups all selected <see cref="CompositionObject"/>s
        /// on the <see cref="Canvas"/>.
        /// </summary>
        /// <seealso cref="UMLAction.Trigger()"/>
        public override void Trigger()
        {
            Shape[] selectedShapes = Canvas.SelectedShapes;

            if (selectedShapes.Length == 0)
            {
                MessageBox.Show("Please select 1 or more object for ungrouping", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            UngroupShapes(selectedShapes);

            base.Trigger();
        }

        /// <summary>
        /// Ungroup the given <see cref="Shape"/>s and extract the sub-<see cref="Shape"/>s
        /// onto <see cref="Canvas"/> if the <see cref="Shape"/> is a <see cref="CompositionObject"/>.
        /// </summary>
        /// <param name="shapes">The <see cref="Shape"/>s to be ungrouped.</param>
        private void UngroupShapes(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.Count > 1) // Then it is a composittion object.
                {
                    Canvas.RemoveShape(shape);

                    while (shape.Count > 0)
                    {
                        Shape tempShape = shape.RemoveFirst();
                        tempShape.IsSelected = false;
                        Canvas.AddShape(tempShape);
                    }
                }
            }
        }
    }
}
