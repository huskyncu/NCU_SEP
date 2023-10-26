using System.Drawing;
using UMLEditor.Views;

namespace UMLEditor.Shapes.BasicObjects
{
    /// <summary>
    /// This class inherits from the <see cref="BasicObject"/> class, acting and
    /// painting itself as a <see cref="Class"/> object.
    /// </summary>
    /// <remarks>
    /// This is a <code>sealed</code> class which means that no class can inhertis
    /// from it.
    /// </remarks>
    public sealed class Class : BasicObject
    {
        /// <summary>
        /// The default width of a <see cref="Class"/> object.
        /// </summary>
        public const int DefaultWidth = 100;

        /// <summary>
        /// The default height of a <see cref="Class"/> object.
        /// </summary>
        public const int DefaultHeight = 130;

        /// <summary>
        /// Generates an instance of <see cref="Class"/> object.
        /// </summary>
        /// <remarks>
        /// The size of generated <see cref="Class"/> object will be
        /// (<see cref="DefaultWidth"/>, <see cref="DefaultHeight"/>).
        /// </remarks>
        public Class()
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Generates an instance of a <see cref="Class"/> object with x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        public Class(int x, int y) : base(x, y)
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Generates an instance of a <see cref="Class"/> object with x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="p">
        /// A <see cref="Point"/> which contains the information about the initial
        /// position which this <see cref="Class"/> should be.
        /// </param>
        public Class(Point p) : base(p.X, p.Y)
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Paint the <see cref="Class"/> onto the <see cref="Canvas"/> singleton object.
        /// </summary>
        /// <seealso cref="BasicObject.Paint"/>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public override void Paint(Graphics g)
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }

            using (Pen pen = new Pen(ForeColor, BorderWidth))
            {
                g.DrawRectangle(pen, X, Y, Width, Height / 3);
                g.DrawRectangle(pen, X, Y + Height / 3, Width, Height / 3);
                g.DrawRectangle(pen, X, Y + 2 * Height / 3, Width, Height / 3);
            }

            using (Brush brush = new SolidBrush(ForeColor))
            {
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                g.DrawString(Name, FontStyle, brush, new Rectangle(X, Y, Width, Height / 3), format);
            }

            base.Paint(g);
        }
    }
}
