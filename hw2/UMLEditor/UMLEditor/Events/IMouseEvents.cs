using System;
using System.Windows.Forms;

namespace UMLEditor.Events
{
    /// <summary>
    /// The <see cref="IMouseEvents"/> interface declares all necessary
    /// methods that should be implemented.
    /// </summary>
    public interface IMouseEvents
    {
        /// <summary>
        /// Handler for that the mouse is clicking on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseClick(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the mouse is double clicking on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseDoubleClick(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the mouse is pressed on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseDown(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the mouse enters the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseEnter(object sender, EventArgs e);

        /// <summary>
        /// Handler for that the mouse hovers the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseHover(object sender, EventArgs e);

        /// <summary>
        /// Handler for that the mouse leaves from the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseLeave(object sender, EventArgs e);

        /// <summary>
        /// Handler for that the mouse is moved on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseMove(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the mouse is released on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseUp(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the wheel of mouse is rolled on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseWheel(object sender, MouseEventArgs e);

        /// <summary>
        /// Handler for that the mouse is dragging on the interested <see cref="object"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        void OnMouseDrag(object sender, MouseDragEventArgs e);
    }
}
