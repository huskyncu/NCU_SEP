using System.Drawing;
using System.Drawing.Drawing2D;
using UMLEditor.Pseudo;
using UMLEditor.Views;

namespace UMLEditor.Shapes.ConnectionLines
{
    public class GenerationLine : Line
    {
        /// <summary>
        /// Generates a <see cref="GenerationLine"/> instance.
        /// </summary>
        public GenerationLine()
        {
            
        }

        /// <summary>
        /// Generates a <see cref="GenerationLine"/> instance with two
        /// <see cref="Port"/>s initialized.
        /// </summary>
        /// <param name="sourcePort">The source <see cref="Port"/> of this <see cref="GenerationLine"/>.</param>
        /// <param name="destinationPort">The destination <see cref="Port"/> of this <see cref="GenerationLine"/>.</param>
        public GenerationLine(Port sourcePort, Port destinationPort) : base(sourcePort, destinationPort)
        {

        }

        /// <summary>
        /// Paints the <see cref="GenerationLine"/> onto the <see cref="Canvas"/>
        /// singleton object.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public override void Paint(Graphics g)
        {
            base.Paint(g);
            
            Matrix oldMatrix = g.Transform;
            g.Transform = TransFormMatrix;

            Point leftTopPoint = HeadDrawingPoint;
            Point rightTopPoint = new Point(HeadDrawingPoint.X + 10, HeadDrawingPoint.Y);
            Point leftBottomPoint = new Point(HeadDrawingPoint.X, HeadDrawingPoint.Y + 10);
            Point[] points = { leftTopPoint, rightTopPoint, leftBottomPoint };

            using (Brush brush = new SolidBrush(BackColor))
            {
                g.FillPolygon(brush, points);
            }

            using (Pen pen = new Pen(ForeColor))
            {
                g.DrawPolygon(pen, points);
            }

            g.Transform = oldMatrix;
        }
    }
}
