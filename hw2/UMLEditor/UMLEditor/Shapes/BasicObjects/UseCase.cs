using System.Drawing;
using UMLEditor.Views;

namespace UMLEditor.Shapes.BasicObjects
{
    /// <summary>
    /// This class inherits from the <see cref="BasicObject"/> class, acting and
    /// painting itself as a <see cref="UseCase"/> object.
    /// </summary>
    /// <remarks>
    /// This is a <code>sealed</code> class which means that no class can inhertis
    /// from it.
    /// </remarks>
    public sealed class UseCase : BasicObject
    {
        /// <summary>
        /// The default width of a <see cref="UseCase"/> object.
        /// </summary>
        public const int DefaultWidth = 120;

        /// <summary>
        /// The default height of a <see cref="UseCase"/> object.
        /// </summary>
        public const int DefaultHeight = 80;

        /// <summary>
        /// Generates an instance of <see cref="UseCase"/> object.
        /// </summary>
        /// <remarks>
        /// The size of generated <see cref="UseCase"/> object will be
        /// (<see cref="DefaultWidth"/>, <see cref="DefaultHeight"/>).
        /// </remarks>
        public UseCase()
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Generates an instance of a <see cref="UseCase"/> object with x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        public UseCase(int x, int y) : base(x, y)
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Generates an instance of a <see cref="UseCase"/> object with x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="p">
        /// A <see cref="Point"/> which contains the information about the initial
        /// position which this <see cref="UseCase"/> should be.
        /// </param>
        public UseCase(Point p) : base(p.X, p.Y)
        {
            SetSize(DefaultWidth, DefaultHeight);
        }

        /// <summary>
        /// Paint the <see cref="UseCase"/> onto the <see cref="Canvas"/> singleton object.
        /// </summary>
        /// <seealso cref="BasicObject.Paint"/>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public override void Paint(Graphics g)
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillEllipse(brush, X, Y, Width, Height);
            }

            using (Pen pen = new Pen(ForeColor, BorderWidth))
            {
                g.DrawEllipse(pen, X, Y, Width, Height);
            }

            using (Brush brush = new SolidBrush(ForeColor))
            {
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                g.DrawString(Name, FontStyle, brush, new Rectangle(X, Y, Width, Height), format);
            }

            base.Paint(g);
        }
    }
}
