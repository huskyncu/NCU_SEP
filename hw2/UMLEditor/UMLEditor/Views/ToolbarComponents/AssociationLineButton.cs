using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// A <see cref="AssociationLineButton"/> button holds the <see cref="AssociationLineMode"/>
    /// and sets it's mode to <see cref="Canvas"/> when it is clicked.
    /// </summary>
    /// <seealso cref="UMLButton"/>
    internal class AssociationLineButton : UMLButton
    {
        /// <summary>
        /// Generates a <see cref="AssociationLineButton"/> instance.
        /// </summary>
        /// <param name="mode">
        /// The corresponding <see cref="Mode"/> this button should holds.
        /// </param>
        /// <param name="toolBar">Parent tool bar control.</param>
        /// <seealso cref="UMLButton(Mode, UMLToolBar)"/>
        internal AssociationLineButton(Mode mode, UMLToolBar toolBar) : base(mode, toolBar)
        {
            Image = Properties.Resources.AssociationLineIcon;
            Name = "AssociationLineButton";
            Text = "Association line tool";
            ToolTipText = "Association line tool";
        }
    }
}
