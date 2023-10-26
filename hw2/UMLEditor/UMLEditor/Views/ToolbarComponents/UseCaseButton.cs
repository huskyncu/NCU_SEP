using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="UseCaseButton"/> button holds the <see cref="UseCaseMode"/>
    /// and sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class UseCaseButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="UseCaseButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal UseCaseButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.UseCaseIcon;
            Name = "UseCaseButton";
            Text = "Use case tool";
            ToolTipText = "Use case tool";
        }
    }
}
