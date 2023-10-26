using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using UMLEditor.Pseudo;
using UMLEditor.Views;

namespace UMLEditor.Shapes.ConnectionLines
{
    /// <summary>
    /// This class inherits the <see cref="Shape"/> class.
    /// This is an abstract class of all line classes.
    /// </summary>
    /// <remarks>
    /// Two ports are initialized for all sub-classes to use.
    /// </remarks>
    public abstract class Line : Shape
    {
        /// <summary>
        /// A transform <see cref="Matrix"/> which represents the current direction of line.
        /// </summary>
        /// <remarks>
        /// This transform <see cref="Matrix"/> will be updated every time the <see cref="Line"/>
        /// is repainted.
        /// </remarks>
        protected Matrix TransFormMatrix;

        /// <summary>
        /// Gets the head (destination) <see cref="Point"/> of <see cref="Line"/>.
        /// </summary>
        protected Point HeadDrawingPoint { get { return GetHeadDrawingPoint(); } }

        /// <summary>
        /// Generates a <see cref="Line"/> instance.
        /// </summary>
        public Line()
        {
            Ports = new Port[2];
        }

        /// <summary>
        /// Generates a <see cref="Line"/> instance with two <see cref="Port"/>s initialized.
        /// </summary>
        /// <param name="sourcePort">The source <see cref="Port"/> of <see cref="Line"/>.</param>
        /// <param name="destinationPort">The destination <see cref="Port"/> of <see cref="Line"/>.</param>
        public Line(Port sourcePort, Port destinationPort)
        {
            Ports = new Port[2];
            Ports[0] = sourcePort;
            Ports[1] = destinationPort;
        }

        public override Port GetNearestPort(Point p)
        {
            return null;
        }

        /// <summary>
        /// Check if the given <see cref="Point"/> is covered by this
        /// <see cref="Line"/> or not.
        /// </summary>
        /// <remarks>
        /// A covers B means that the position B is within the boundary of B.
        /// </remarks>
        /// <param name="p">The <see cref="Point"/> to be checked.</param>
        /// <returns>
        /// Returns <code>true</code> if the given <see cref="Point"/> is covered
        /// by this <see cref="Line"/>; otherwise, returns <code>false</code>.
        /// </returns>
        public override bool IsCovers(Point p)
        {
            Port firstPort = GetPort(0);
            Port secondPort = GetPort(1);

            Point l1 = new Point(firstPort.X, firstPort.Y);
            Point l2 = new Point(secondPort.X, secondPort.Y);

            double distance = Math.Abs((l2.X - l1.X) * (l1.Y - p.Y) - (l1.X - p.X) * (l2.Y - l1.Y)) /
                    Math.Sqrt(Math.Pow(l2.X - l1.X, 2) + Math.Pow(l2.Y - l1.Y, 2));
            
            return distance < 5 && IsWithinCircle(p);
        }

        /// <summary>
        /// Moves this <see cref="Shape"/> by the given offsets.
        /// </summary>
        /// <param name="offsetX">The x-axis offset.</param>
        /// <param name="offsetY">The y-axis offset.</param>
        /// <remarks>
        /// This method <code>override</code>s the <see cref="Shape.Move"/>
        /// method, and leave it doing nothing.
        /// </remarks>
        public override void Move(int offsetX, int offsetY)
        {
            // Do nothing.
        }

        /// <summary>
        /// Paints this <see cref="Line"/> onto the <see cref="Canvas"/> singleton.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        /// <seealso cref="Shape.Paint"/>
        public override void Paint(Graphics g)
        {
            UpdateLocation();
            UpdateSize();

            base.Paint(g);

            using (Pen pen = new Pen(ForeColor))
            {
                g.DrawLine(pen, Ports[0].X, Ports[0].Y, Ports[1].X, Ports[1].Y);
            }

            // The following code generates the transform matrix for
            // the head geometry of this line to perform a rotation.
            if (Ports[1] == null) return;

            int x1 = Ports[0].X;
            int y1 = Ports[0].Y;
            int x2 = Ports[1].X;
            int y2 = Ports[1].Y;

            double dx = x2 - x1, dy = y2 - y1;
            double angle = (Math.Atan2(dy, dx) * 180.0 / Math.PI) + 135.0;

            Point leftTopPoint = HeadDrawingPoint;
            Point rightTopPoint = new Point(x2 + 10, y2);
            Point leftBottomPoint = new Point(x2, y2 + 10);
            Point[] points = { leftTopPoint, rightTopPoint, leftBottomPoint };

            Rectangle rectangle = new Rectangle(x2, y2, 10, 10);

            Matrix matrix = new Matrix(rectangle, points);
            matrix.RotateAt(Convert.ToSingle(angle), leftTopPoint);

            TransFormMatrix = matrix;
        }

        /// <summary>
        /// Gets the head <see cref="Point"/> of <see cref="Line"/>.
        /// </summary>
        /// <returns>
        /// Returns the head <see cref="Point"/> of <see cref="Line"/>. If the head <see cref="Point"/> is not
        /// found, returns the starting <see cref="Point"/> of <see cref="Line"/>. If no <see cref="Port"/>
        /// exists in this <see cref="Line"/>, returns an empty <see cref="Point"/>.
        /// </returns>
        private Point GetHeadDrawingPoint()
        {
            if (Ports[1] != null) return new Point(Ports[1].X, Ports[1].Y);
            if (Ports[0] != null) return new Point(Ports[0].X, Ports[0].Y);

            return new Point();
        }

        /// <summary>
        /// Automatically updates the location of this <see cref="Line"/>.
        /// </summary>
        /// <remarks>
        /// The location of <see cref="Line"/> is determined by the starting <see cref="Port"/>
        /// of <see cref="Line"/>.
        /// </remarks>
        private void UpdateLocation()
        {
            X = Math.Min(Ports[0].X, Ports[1].X);
            Y = Math.Min(Ports[0].Y, Ports[1].Y);
        }

        /// <summary>
        /// Automatically updates the size of this <see cref="Line"/>.
        /// </summary>
        /// <remarks>
        /// The size of <see cref="Line"/> is determined by the two <see cref="Port"/>s in
        /// this <see cref="Line"/>.
        /// </remarks>
        private void UpdateSize()
        {
            int width = Math.Abs(Ports[0].X - Ports[1].X);
            int height = Math.Abs(Ports[0].Y - Ports[1].Y);
            SetSize(width, height);
        }

        /// <summary>
        /// Check if the given <see cref="Point"/> is within
        /// the circle formed by this <see cref="Line"/>.
        /// </summary>
        /// <param name="p">The <see cref="Point"/> to be checked.</param>
        /// <returns>
        /// Returns True if the given <see cref="Point"/> is within the circle
        /// formed by this <see cref="Line"/>; returns False otherwise.
        /// </returns>
        private bool IsWithinCircle(Point p)
        {
            Port p1 = GetPort(0);
            Port p2 = GetPort(1);
            Point middlePoint = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            double radius = Math.Sqrt(Math.Pow(p1.X - middlePoint.X, 2) + Math.Pow(p1.Y - middlePoint.Y, 2));
            double distance = Math.Sqrt(Math.Pow(p.X - middlePoint.X, 2) + Math.Pow(p.Y - middlePoint.Y, 2));
            return distance <= radius;
        }

        /// <summary>
        /// Destructor of <see cref="Line"/> which sets all relative <see cref="Port"/>
        /// to invisible.
        /// </summary>
        ~Line()
        {
            foreach (Port port in Ports)
            {
                if (port != null)
                {
                    port.Visible = false;
                }
            }
        }
    }
}
