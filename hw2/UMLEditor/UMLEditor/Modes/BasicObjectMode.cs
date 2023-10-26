using System;
using System.Windows.Forms;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating <see cref="BasicObject"/> when mosue events fired.
    /// </summary>
    /// <remarks>
    /// This is an <code>abstract class</code> that cannot be created directly.
    /// </remarks>
    /// <seealso cref="BasicObject"/>
    public abstract class BasicObjectMode : Mode
    {
        /// <summary>
        /// Generates a <see cref="BasicObjectMode"/>.
        /// </summary>
        /// <remarks>
        /// This is an <code>abstract class</code> that cannot be created directly.
        /// </remarks>
        /// <seealso cref="Mode()"/>
        protected BasicObjectMode()
        {
            
        }

        /// <summary>
        /// Performs the mouse wheel event.
        /// Adds the newly created <see cref="Shape"/> onto <see cref="Canvas"/>
        /// for painting.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            Shape.SetLocation(e.X, e.Y);
            Canvas.AddShape(Shape);

            base.OnMouseDown(sender, e);
        }
    }
}
