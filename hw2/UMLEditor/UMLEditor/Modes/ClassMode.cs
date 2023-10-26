using System;
using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating <see cref="Class"/> when mosue events fired.
    /// </summary>
    /// <seealso cref="Class"/>
    public class ClassMode : BasicObjectMode
    {
        /// <summary>
        /// Generates a <see cref="ClassMode"/> instance.
        /// </summary>
        /// <seealso cref="BasicObjectMode()"/>
        public ClassMode()
        {
            ModeDescription = "Class:\nPress mouse's left button to create a default UML class.";
        }

        /// <summary>
        /// Performs the mouse down event.
        /// Creates a <see cref="Class"/> <see cref="Shape"/> and adds it onto <see cref="Canvas"/>
        /// for painting.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="BasicObjectMode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            Shape = new Class(e.X, e.Y);
            base.OnMouseDown(sender, e);
        }
    }
}
