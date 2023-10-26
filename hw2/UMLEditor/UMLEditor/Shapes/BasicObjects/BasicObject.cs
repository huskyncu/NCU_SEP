using UMLEditor.Pseudo;

namespace UMLEditor.Shapes.BasicObjects
{
    /// <summary>
    /// This class inherits the <see cref="Shape"/> class.
    /// This is an abstract class of all basic object classes.
    /// </summary>
    /// <remarks>
    /// Four ports are initialized for all sub-classes to use.
    /// </remarks>
    public abstract class BasicObject : Shape
    {
        /// <summary>
        /// Gets how many <see cref="Port"/>s a <see cref="BasicObject"/> should has.
        /// </summary>
        public const int PortCount = 4;

        /// <summary>
        /// Generates a <see cref="BasicObject"/> instance.
        /// </summary>
        protected BasicObject()
        {
            InitializePorts();
        }

        /// <summary>
        /// Generates a <see cref="BasicObject"/> instance with the x and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="x">The x-axis value to be set.</param>
        /// <param name="y">The y-axis value to be set.</param>
        protected BasicObject(int x, int y) : base(x, y)
        {
            InitializePorts();
        }
        
        /// <summary>
        /// Sets the size of this <see cref="BasicObject"/>.
        /// </summary>
        /// <param name="width">The width value to be set.</param>
        /// <param name="height">The height value to be set.</param>
        /// <seealso cref="Shape.Paint"/>
        /// <remarks>
        /// The position of four <see cref="Port"/>s will be updated, too.
        /// </remarks>
        public override void SetSize(int width, int height)
        {
            base.SetSize(width, height);
            Ports[0].SetLocation(X, Y + Height / 2); //Left
            Ports[1].SetLocation(X + Width / 2, Y); //Top
            Ports[2].SetLocation(X + Width / 2, Y + Height); //Down
            Ports[3].SetLocation(X + Width, Y + Height / 2); //Right
        }

        /// <summary>
        /// Initializes the four <see cref="Port"/>s of this <see cref="BasicObject"/>.
        /// </summary>
        private void InitializePorts()
        {
            Ports = new Port[PortCount];
            for (int i = 0; i < Ports.Length; i++)
            {
                Ports[i] = new Port();
            }
        }
    }
}
