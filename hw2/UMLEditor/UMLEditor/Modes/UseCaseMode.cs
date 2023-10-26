using System;
using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating <see cref="UseCaseMode"/> when mosue events fired.
    /// </summary>
    /// <seealso cref="UseCase"/>
    public class UseCaseMode : BasicObjectMode
    {
        /// <summary>
        /// Generates a <see cref="UseCaseMode"/> instance.
        /// </summary>
        /// <seealso cref="BasicObjectMode()"/>
        public UseCaseMode()
        {
            ModeDescription = "Use case:\nPress mouse's left button to create a default Use Case class.";
        }

        /// <summary>
        /// Performs the mouse down event.
        /// Creates a <see cref="UseCase"/> <see cref="Shape"/> and adds it onto <see cref="Canvas"/>
        /// for painting.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="BasicObjectMode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            Shape = new UseCase(e.X, e.Y);
            base.OnMouseDown(sender, e);
        }
    }
}
