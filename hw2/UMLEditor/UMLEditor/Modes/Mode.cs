using System;
using System.Windows.Forms;
using UMLEditor.Events;
using UMLEditor.Shapes;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the corresponding operations for triggering when mosue events fired.
    /// </summary>
    /// <remarks>
    /// This is an <code>abstract class</code> that cannot be created directly.
    /// The <code>class</code> inherits from this <code>abstract class</code> can
    /// <code>override</code>s the mouse event handlers for performing corresponding
    /// operations.
    /// </remarks>
    /// <seealso cref="Shape"/>
    public abstract class Mode : IMouseEvents
    {
        /// <summary>
        /// Gets or sets the discription of this <see cref="Mode"/>.
        /// </summary>
        /// <remarks>Facade of <see cref="ModeDescription"/></remarks>
        public string Description
        {
            get { return ModeDescription; }
            set { SetDescription(value); }
        }

        /// <summary>
        /// Holds the discription of this <see cref="Mode"/>.
        /// </summary>
        protected string ModeDescription;

        /// <summary>
        /// Holds the <see cref="Shape"/> for interaction.
        /// </summary>
        protected Shape Shape;

        /// <summary>
        /// Holds the <see cref="Canvas"/> singleton <seealso cref="object"/> for
        /// manipulating <see cref="Shape"/>s.
        /// </summary>
        protected Canvas Canvas;

        /// <summary>
        /// Initializes the <see cref="Mode"/> instance.
        /// </summary>
        /// <remarks>
        /// This constructor is invisible for those who are not in the same
        /// inheritance chain.
        /// </remarks>
        protected Mode()
        {
            ModeDescription = string.Empty;
            Shape = null;
            Canvas = Canvas.GetInstance();
        }

        /// <summary>
        /// Performs the mouse click event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseClick(object sender, MouseEventArgs e)
        {
            Canvas.Invalidate();
        }

        /// <summary>
        /// Performs the mouse double click event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Performs the mouse down event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseDown(object sender, MouseEventArgs e)
        {
            Canvas.Invalidate();
        }

        /// <summary>
        /// Performs the mouse drag event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseDrag(object sender, MouseDragEventArgs e)
        {
            Canvas.Invalidate();
        }

        /// <summary>
        /// Performs the mouse enter event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseEnter(object sender, EventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Performs the mouse hover event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseHover(object sender, EventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Performs the mouse leave event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseLeave(object sender, EventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Performs the mouse move event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Performs the mouse up event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseUp(object sender, MouseEventArgs e)
        {
            Canvas.Invalidate();
        }

        /// <summary>
        /// Performs the mouse wheel event.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Base handler.</remarks>
        public virtual void OnMouseWheel(object sender, MouseEventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Sets the description of <see cref="Mode"/>.
        /// </summary>
        /// <param name="description"></param>
        private void SetDescription(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                ModeDescription = description;
            }
        }
    }
}
