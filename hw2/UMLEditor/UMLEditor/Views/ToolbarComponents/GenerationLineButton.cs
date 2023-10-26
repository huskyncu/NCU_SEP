using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="GenerationLineButton"/> button holds the <see cref="GenerationLineMode"/>
    /// and sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class GenerationLineButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="GenerationLineButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal GenerationLineButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.GenerationLineIcon;
            Name = "GenerationLineButton";
            Text = "Generation line tool";
            ToolTipText = "Generation line tool";
        }
    }
}
