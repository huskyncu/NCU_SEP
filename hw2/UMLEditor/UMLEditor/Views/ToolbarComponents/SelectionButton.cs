using System;
using System.Windows.Forms;
using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="SelectionButton"/> holds the <see cref="SelectMode"/> and
    /// sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class SelectionButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="SelectionButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal SelectionButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.SelectIcon;
            Name = "SelectionButton";
            Text = "Selection tool";
            ToolTipText = "Selection tool";
            CheckStateChanged += OnCheckStateChanged;
        }

        /// <summary>
        /// Fires the <see cref="Mode.OnMouseUp"/> when checked state changed.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> that fires the event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> that holds information of event.
        /// </param>
        private void OnCheckStateChanged(object sender, EventArgs e)
        {
            Mode.OnMouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, -1, -1, 0));
        }
    }
}
