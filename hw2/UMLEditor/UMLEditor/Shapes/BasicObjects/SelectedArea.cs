using System.Drawing;
using UMLEditor.Views;

namespace UMLEditor.Shapes.BasicObjects
{
    /// <summary>
    /// This class inherits from the <see cref="Shape"/> class, used to form an
    /// area for multiple <see cref="Shape"/> selection and draw it onto
    /// the <see cref="Canvas"/>.
    /// </summary>
    /// <remarks>
    /// This is a <code>sealed</code> class which means that no class can inhertis
    /// from it.
    /// </remarks>
    public sealed class SelectedArea : Shape
    {
        private static readonly Color DefaultForeColor = Color.Gray;
        public static readonly Color DefaultBackColor = Color.FromArgb(50, 100, 100, 100);

        /// <summary>
        /// Generates an instance of <see cref="SelectedArea"/> object.
        /// </summary>
        public SelectedArea()
        {
            Initialization();
        }

        /// <summary>
        /// Generates a <see cref="SelectedArea"/> instance with the x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <seealso cref="Shape"/>
        /// <param name="x">The x-axis value to be set.</param>
        /// <param name="y">The y-axis value to be set.</param>
        public SelectedArea(int x, int y) : base(x, y)
        {
            Initialization();
        }

        /// <summary>
        /// Generates a <see cref="SelectedArea"/> instance with x-axis, y-axis, width
        /// and height attributes initialized.
        /// </summary>
        /// <seealso cref="Shape"/>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public SelectedArea(int x, int y, int width, int height) : base(x, y, width, height)
        {
            Initialization();
        }

        /// <summary>
        /// Moves this <see cref="SelectedArea"/> by the given offsets.
        /// </summary>
        /// <remarks>
        /// This method overrides <see cref="Shape.Move"/> without calling parent's method.
        /// </remarks>
        /// <param name="offsetX">The x-axis offset.</param>
        /// <param name="offsetY">The y-axis offset.</param>
        public override void Move(int offsetX, int offsetY)
        {
            SetLocation(X + offsetX, Y + offsetY);
        }

        /// <summary>
        /// Paint the <see cref="SelectedArea"/> onto the <see cref="Canvas"/> singleton object.
        /// </summary>
        /// <seealso cref="Shape.Paint"/>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public override void Paint(Graphics g)
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }

            using (Pen pen = new Pen(ForeColor))
            {
                g.DrawRectangle(pen, X, Y, Width, Height);
            }
        }

        /// <summary>
        /// Sets the location of this <see cref="SelectedArea"/> to the given x and y-axis value.
        /// </summary>
        /// <param name="x">The x-axis value of the new position.</param>
        /// <param name="y">The y-axis value of the new position.</param>
        /// <remarks>
        /// This method overrides <see cref="Shape.SetLocation"/> without calling parent's method.
        /// </remarks>
        public override void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes the <see cref="SelectedArea"/> object.
        /// </summary>
        private void Initialization()
        {
            ForeColor = DefaultForeColor;
            BackColor = DefaultBackColor;
        }
    }
}
