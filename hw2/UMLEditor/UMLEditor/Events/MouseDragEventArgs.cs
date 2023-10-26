using System.Windows.Forms;

namespace UMLEditor.Events
{
    /// <summary>
    /// The <seealso cref="System.EventHandler"/> of mouse dragged event.
    /// </summary>
    /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
    /// <param name="e">The <seealso cref="System.EventArgs"/> containing information of mouse.</param>
    public delegate void MouseDragEventHandler(object sender, MouseDragEventArgs e);

    /// <summary>
    /// The <see cref="System.EventArgs"/> which holds the information of mouse
    /// when mouse is dragged.
    /// </summary>
    public class MouseDragEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Gets the x-axis offset of mouse.
        /// </summary>
        /// <remarks>
        /// This is the facade of <see cref="_offsetX"/>.
        /// </remarks>
        public int OffsetX { get { return _offsetX; } }

        /// <summary>
        /// Gets the y-axis offset of mouse.
        /// </summary>
        /// <remarks>
        /// This is the facade of <see cref="_offsetY"/>.
        /// </remarks>
        public int OffsetY { get { return _offsetY; } }

        /// <summary>
        /// Holds the x-axis offset information of mouse.
        /// </summary>
        private int _offsetX;

        /// <summary>
        /// Holds the y-axis offset information of mouse.
        /// </summary>
        private int _offsetY;

        /// <summary>
        /// Generates a <see cref="MouseDragEventArgs"/> instance.
        /// </summary>
        /// <param name="button">The clicked button of mouse.</param>
        /// <param name="clicks">The clicked count of mouse.</param>
        /// <param name="x">The x-axis position of mouse.</param>
        /// <param name="y">The y-axis position of mouse.</param>
        /// <param name="offsetX">The x-axis offset of mouse.</param>
        /// <param name="offsetY">The y-axis offset of mouse.</param>
        /// <param name="delta">The delta value of mouse wheel rolled.</param>
        public MouseDragEventArgs(MouseButtons button, int clicks, int x, int y, int offsetX, int offsetY, int delta)
            : base(button, clicks, x, y, delta)
        {
            _offsetX = offsetX;
            _offsetY = offsetY;
        }
    }
}
