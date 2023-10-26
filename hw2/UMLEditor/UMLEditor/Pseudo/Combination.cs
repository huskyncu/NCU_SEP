using UMLEditor.Shapes;
using UMLEditor.Views;

namespace UMLEditor.Pseudo
{
    /// <summary>
    /// This class stores a <see cref="Shapes.ConnectionLines.Line"/> and a <see cref="Shapes.BasicObjects.BasicObject"/>,
    /// thus binding these two <see cref="Shape"/>s together.
    /// </summary>
    public class Combination
    {
        /// <summary>
        /// Gets or sets the source <see cref="Shapes.BasicObjects.BasicObject"/>.
        /// </summary>
        public Shape Source { get; set; }

        /// <summary>
        /// Gets or sets the destination <see cref="Shapes.BasicObjects.BasicObject"/>
        /// </summary>
        public Shape Destination { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Shapes.ConnectionLines.Line"/>.
        /// </summary>
        public Shape Line { get; set; }

        /// <summary>
        /// Generates a <see cref="Combination"/> instance.
        /// </summary>
        public Combination()
        {
            Source = null;
            Destination = null;
            Line = null;
        }

        /// <summary>
        /// Destroy this <see cref="Combination"/> itself. Be aware, the <see cref="Combination"/>
        /// list in source and destination <see cref="Shape"/> will be modified.
        /// </summary>
        public void Destroy()
        {
            if (Source != null)
            {
                Source.RemoveCombination(this);
            }

            if (Destination != null)
            {
                Destination.RemoveCombination(this);
            }

            if (Line != null)
            {
                Line.IsSelected = false;
                Canvas.GetInstance().RemoveShape(Line);
            }
        }
    }
}
