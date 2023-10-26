using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="CompositionLineButton"/> button holds the <see cref="CompositionLineMode"/>
    /// and sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class CompositionLineButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="CompositionLineButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal CompositionLineButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.CompositionLineIcon;
            Name = "CompositionLineButton";
            Text = "Composition line tool";
            ToolTipText = "Composition line tool";
        }
    }
}
