using System;
using System.Drawing;
using System.Windows.Forms;
using UMLEditor.Events;
using UMLEditor.Pseudo;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Shapes.ConnectionLines;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating <see cref="Line"/> when mosue events fired.
    /// </summary>
    /// <remarks>
    /// This is an <code>abstract class</code> that cannot be created directly.
    /// </remarks>
    /// <seealso cref="Line"/>
    public abstract class LineMode : Mode
    {
        /// <summary>
        /// Holds the <see cref="UMLEditor.Pseudo.Port"/> of source
        /// <see cref="BasicObject"/> <see cref="Shape"/>.
        /// </summary>
        protected Port SourcePort;

        /// <summary>
        /// Holds the <see cref="UMLEditor.Pseudo.Port"/> of destination
        /// <see cref="BasicObject"/> <see cref="Shape"/>.
        /// </summary>
        protected Port TargetPort;

        /// <summary>
        /// Holds the source <see cref="Shape"/>.
        /// </summary>
        protected Shape SourceShape;

        /// <summary>
        /// Generates a <see cref="LineMode"/> instance.
        /// </summary>
        /// <remarks>
        /// This is an <code>abstract class</code> that cannot be created directly.
        /// </remarks>
        /// <seealso cref="Mode()"/>
        protected LineMode()
        {
            SourcePort = null;
            TargetPort = null;
            SourceShape = null;
        }

        /// <summary>
        /// Performs the mouse down event.
        /// If mouse is clicking on a <see cref="BasicObject"/>, adds the newly created
        /// <see cref="Line"/> onto <see cref="Canvas"/>, also adds a <see cref="Combination"/>
        /// to source <see cref="BasicObject"/>. If mouse is not pressing on a <see cref="BasicObject"/>,
        /// dispose the created <see cref="Line"/> object and do nothing.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            bool created = false;
            Point mousePoint = new Point(e.X, e.Y);

            for (int i = Canvas.GetShapeCount() - 1; i >= 0; i--)
            {
                Shape currentShape = Canvas.GetShape(i);
                SourcePort = currentShape.GetNearestPort(mousePoint);
                if (currentShape.IsCovers(mousePoint) && SourcePort != null)
                {
                    Shape.SetPort(0, SourcePort); // Set source port to pressed object
                    SourcePort.Visible = true; // Set port to visible
                    TargetPort = new Port(e.X, e.Y);
                    Shape.SetPort(1, TargetPort); // Set destination port to the current position of mouse
                    Canvas.AddShape(Shape); // Add line to canvas
                    created = true;
                    SourceShape = currentShape;
                    break;
                }
            }

            if (!created) Shape = null;

            base.OnMouseDown(sender, e);
        }

        /// <summary>
        /// Performs the mouse drag event.
        /// If the <see cref="Line"/> <see cref="Shape"/> is previously created, update the destination
        /// <see cref="Pseudo.Port"/> to the position of mouse; else, do nothing.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseDrag"/>
        public override void OnMouseDrag(object sender, MouseDragEventArgs e)
        {
            if (Shape != null)
            {
                int ofx = e.OffsetX; //Store displacements
                int ofy = e.OffsetY;
                TargetPort.Move(ofx, ofy); //Update target port to current position of mouse
                Shape.SetPort(1, TargetPort);
                base.OnMouseDrag(sender, e);
            }
        }

        /// <summary>
        /// Performs the mouse up event.
        /// If the <see cref="Line"/> <see cref="Shape"/> is previously created, and the mouse is
        /// released on a specific <see cref="BasicObject"/>, combines this <see cref="BasicObject"/>
        /// with this <see cref="Line"/>, thus completely create a <see cref="Line"/> <seealso cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseUp"/>
        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (Shape == null) return;

            bool success = false;
            Point mousePoint = new Point(e.X, e.Y);

            for (int i = Canvas.GetShapeCount() - 1; i >= 0; i--)
            {
                Shape currentShape = Canvas.GetShape(i);
                TargetPort = currentShape.GetNearestPort(mousePoint);
                if (currentShape.IsCovers(mousePoint) && !SourceShape.Equals(currentShape) && !Shape.Equals(currentShape) && TargetPort != null)
                {
                    Shape.SetPort(1, TargetPort);
                    ConstructCombination(SourceShape, currentShape, Shape);
                    Shape.IsSelected = false;
                    success = true;
                    break;
                }
            }

            if (!success) RemoveCreateFailedLine();

            base.OnMouseUp(sender, e);
        }

        /// <summary>
        /// Creates a <see cref="Combination"/> between the source, destination object and line.
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <param name="destinationObj"></param>
        /// <param name="line"></param>
        private void ConstructCombination(Shape sourceObj, Shape destinationObj, Shape line)
        {
            Combination combination = new Combination();
            combination.Source = sourceObj;
            combination.Destination = destinationObj;
            combination.Line = line;
            sourceObj.AddCombination(combination);
            destinationObj.AddCombination(combination);
            line.AddCombination(combination);
        }

        /// <summary>
        /// Removes the <see cref="Line"/> that is failed to be created.
        /// </summary>
        private void RemoveCreateFailedLine()
        {
            Shape.GetPort(0).Visible = false;
            Canvas.RemoveShape(Shape);
        }
    }
}
