using System;
using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.ConnectionLines;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating <see cref="AssociationLine"/> when mosue events fired.
    /// </summary>
    /// <seealso cref="AssociationLine"/>
    public class AssociationLineMode : LineMode
    {
        /// <summary>
        /// Generates a <see cref="AssociationLine"/> instance.
        /// </summary>
        /// <seealso cref="LineMode()"/>
        public AssociationLineMode()
        {
            ModeDescription = "Association line:\nPress on a UML or Use Case class,\n" +
                "remain the mouse's left button pressed,\n" +
                "drag it to another UML or Use Case class and release left button to create an Associate Line.";
        }

        /// <summary>
        /// Performs the mouse down event.
        /// Creates a <see cref="AssociationLine"/> <see cref="Shape"/> and adds it onto <see cref="Canvas"/>
        /// for painting.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="BasicObjectMode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            Shape = new AssociationLine();
            base.OnMouseDown(sender, e);
        }
    }
}
