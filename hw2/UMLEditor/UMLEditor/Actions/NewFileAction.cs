using UMLEditor.Shapes;
using UMLEditor.Views;

namespace UMLEditor.Actions
{
    /// <summary>
    /// An <see cref="UMLAction"/> which performs the new file operation.
    /// </summary>
    /// <seealso cref="UMLAction"/>
    internal class NewFileAction : UMLAction
    {
        /// <summary>
        /// Generates an <see cref="NewFileAction"/> instance.
        /// </summary>
        /// <seealso cref="UMLAction()"/>
        internal NewFileAction()
        {
            
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Clears out all <see cref="Shape"/>s on the
        /// <see cref="Canvas"/>.
        /// </summary>
        /// <seealso cref="UMLAction.Trigger()"/>
        public override void Trigger()
        {
            Canvas.RemoveAll();
            base.Trigger();
        }
    }
}
