using UMLEditor.Pseudo;

namespace UMLEditor.Shapes.ConnectionLines
{
    public class AssociationLine : Line
    {
        /// <summary>
        /// Generates a <see cref="AssociationLine"/> instance.
        /// </summary>
        public AssociationLine()
        {

        }

        /// <summary>
        /// Generates a <see cref="AssociationLine"/> instance with two
        /// <see cref="Port"/>s initialized.
        /// </summary>
        /// <param name="sourcePort">The source <see cref="Port"/> of this <see cref="AssociationLine"/>.</param>
        /// <param name="destinationPort">The destination <see cref="Port"/> of this <see cref="AssociationLine"/>.</param>
        public AssociationLine(Port sourcePort, Port destinationPort) : base(sourcePort, destinationPort)
        {

        }
    }
}
