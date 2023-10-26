using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="ClassButton"/> button holds the <see cref="ClassMode"/>
    /// and sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class ClassButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="ClassButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal ClassButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.ClassIcon;
            Name = "ClassButton";
            Text = "Class tool";
            ToolTipText = "Class tool";
        }
    }
}
