using System;
using System.Windows.Forms;
using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// This <code>class</code> acts as a tool bar button of UML Editor, holding
    /// a corresponding <see cref="Modes.Mode"/> to be set to <see cref="Canvas"/>
    /// after this button clicked.
    /// </summary>
    /// <remarks>
    /// This is an <code>abstract class</code> that cannot be created directly by
    /// those who not in the same inheritance chain.
    /// </remarks>
    public abstract class UMLButton : ToolStripButton
    {
        /// <summary>
        /// Holds the corresponding <see cref="Modes.Mode"/>.
        /// </summary>
        protected Mode Mode;

        /// <summary>
        /// Holds the parent tool bar control.
        /// </summary>
        private readonly UMLToolBar _parenToolBar;

        /// <summary>
        /// Generates an <see cref="UMLButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Modes.Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        protected UMLButton(Mode mode, UMLToolBar toolBar)
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image;
            Size = new System.Drawing.Size(20, 20);
            Click += OnClickEvent;
            Mode = mode;
            _parenToolBar = toolBar;
        }

        /// <summary>
        /// Performs the event when button clicked.
        /// Sets the <see cref="Modes.Mode"/> of <see cref="Canvas"/> to the
        /// one held by this button.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> that fires the event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> that holds information of event.
        /// </param>
        private void OnClickEvent(object sender, EventArgs e)
        {
            _parenToolBar.SetFocusItem(this);
            Canvas.GetInstance().CurrentMode = Mode;
        }
    }
}
