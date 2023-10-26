using System;
using System.Drawing;
using UMLEditor.Shapes;
using UMLEditor.Views;

namespace UMLEditor.Pseudo
{
    /// <summary>
    /// This class acts as a <see cref="Port"/> of a <see cref="Shape"/>.
    /// </summary>
    /// <remarks>
    /// One <see cref="Shape"/> may has multiple <see cref="Port"/>s or
    /// has not a single one. For <see cref="Port"/> information, please
    /// go watch the <code>class</code> directly.
    /// </remarks>
    public class Port
    {
        /// <summary>
        /// Gets the x-axis value of this <see cref="Port"/>.
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// Gets the y-axis value of this <see cref="Port"/>.
        /// </summary>
        public int Y { get; protected set; }

        /// <summary>
        /// Gets the length of each side.
        /// </summary>
        public const int BorderLength = 10;

        /// <summary>
        /// Gets or sets the visibility of this <see cref="Port"/>.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the movability of this <see cref="Port"/>.
        /// </summary>
        public bool Movable { get; set; }

        /// <summary>
        /// Gets the default color.
        /// </summary>
        public static readonly Color DefaultColor = Color.White;

        /// <summary>
        /// Generatest a <see cref="Port"/> instance.
        /// </summary>
        public Port()
        {
            X = 0;
            Y = 0;
            Visible = false;
            Movable = false;
        }

        /// <summary>
        /// Generates a <see cref="Port"/> instance with x and y-axis
        /// values initialized.
        /// </summary>
        /// <param name="x">The value of x-axis position.</param>
        /// <param name="y">The value of y-axis position.</param>
        public Port(int x, int y)
        {
            X = x;
            Y = y;
            Visible = false;
            Movable = true;
        }

        /// <summary>
        /// Gets the distance between this <see cref="Port"/> and the
        /// given <see cref="Point"/>.
        /// </summary>
        /// <param name="p">The <see cref="Point"/> to be compared with this <see cref="Port"/>.</param>
        /// <returns>
        /// Returns a <seealso cref="double"/> representing the distance between this <see cref="Port"/>
        /// and the given <see cref="Point"/>.
        /// </returns>
        public double GetDistanceFrom(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        /// <summary>
        /// Moves this <see cref="Port"/> by a given offset.
        /// </summary>
        /// <param name="offsetX">The value of x-axis offset.</param>
        /// <param name="offsetY">The value of y-axis offset.</param>
        public void Move(int offsetX, int offsetY)
        {
            if (Movable)
            {
                X += offsetX;
                Y += offsetY;
            }
        }

        /// <summary>
        /// Paints itself on the <see cref="Canvas"/>.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public void Paint(Graphics g)
        {
            if (Visible)
            {
                using (Brush brush = new SolidBrush(DefaultColor))
                {
                    g.FillRectangle(brush, X - BorderLength / 2, Y - BorderLength / 2, BorderLength, BorderLength);
                }
            }
        }

        /// <summary>
        /// Sets the location of this <see cref="Port"/>.
        /// </summary>
        /// <param name="x">The new x-axis value.</param>
        /// <param name="y">The new y-axis value.</param>
        public void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
