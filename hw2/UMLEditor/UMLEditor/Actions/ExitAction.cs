using System.Windows.Forms;

namespace UMLEditor.Actions
{
    /// <summary>
    /// An <see cref="UMLAction"/> which performs the exit operation.
    /// </summary>
    /// <seealso cref="UMLAction"/>
    internal class ExitAction : UMLAction
    {
        /// <summary>
        /// Generates an <see cref="ExitAction"/> instance.
        /// </summary>
        /// <seealso cref="UMLAction()"/>
        internal ExitAction()
        {
            
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Exits the UML Editor program.
        /// </summary>
        /// <seealso cref="UMLAction.Trigger()"/>
        public override void Trigger()
        {
            Application.Exit();
        }
    }
}
