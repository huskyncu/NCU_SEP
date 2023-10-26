using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UMLEditor.Pseudo;
using UMLEditor.Views;

namespace UMLEditor.Shapes
{
    /// <summary>
    /// This is an abstract class for all shape classes.
    /// This class acts as a drawable shape, holding and providing properties
    /// of a shape should has such as width, height, color, and so on.
    /// </summary>
    /// <remarks>
    /// This class defines all basic properties and methods of a shape.
    /// Public properties can only be accessed through the <code>getter</code>
    /// and <code>setter</code> so the properties are well protected,
    /// also give the convenience of use by developers.
    /// Classes which inherits this <see cref="Shape"/> class should all follow
    /// the coding style of this class to keep consistency and safe accessibility
    /// of members.
    /// </remarks>
    public abstract class Shape
    {
        /// <summary>
        /// The name of <see cref="Shape"/>.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_name"/> member.
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { SetName(value); }
        }
        /// <summary>
        /// Gets or sets the x-axis attribute of <see cref="Shape"/>.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_x"/> member.
        /// </remarks>
        public int X
        {
            get { return _x; }
            set { SetX(value); }
        }

        /// <summary>
        /// Gets or sets the y-axis attribute of <see cref="Shape"/>.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_y"/> member.
        /// </remarks>
        public int Y
        {
            get { return _y; }
            set { SetY(value); }
        }

        /// <summary>
        /// Gets or sets the width attribute of <see cref="Shape"/>.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_width"/> member.
        /// </remarks>
        public int Width
        {
            get { return _width; }
            set { SetWidth(value); }
        }

        /// <summary>
        /// Gets or sets the height attribute of <see cref="Shape"/>.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_height"/> member.
        /// </remarks>
        public int Height
        {
            get { return _height; }
            set { SetHeight(value); }
        }

        /// <summary>
        /// Gets or sets if the <see cref="Shape"/> is selected or not.
        /// </summary>
        /// <remarks>
        /// This is a facade for the <see cref="_isSelected"/> member.
        /// </remarks>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetSelected(value); }
        }

        /// <summary>
        /// Gets how many inner <see cref="Shape"/>s it contains.
        /// </summary>
        /// <remarks>
        /// This is a facade for the count attribute of the <see cref="Shapes"/> member.
        /// </remarks>
        public int Count { get { return GetShapesCount(); } }

        /// <summary>
        /// Gets or sets the foreground color of <see cref="Shape"/>.
        /// </summary>
        public Color ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of <see cref="Shape"/>.
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Font"/> style of <see cref="Shape"/>.
        /// </summary>
        public Font FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the border width of this <see cref="Shape"/>.
        /// </summary>
        public int BorderWidth { get; set; }

        /// <summary>
        /// The <see cref="Combination"/>(s) it bound to.
        /// </summary>
        protected List<Combination> Combinations;

        /// <summary>
        /// The inner <see cref="Shape"/>(s) it contains.
        /// </summary>
        protected List<Shape> Shapes;

        /// <summary>
        /// Stores all <see cref="Port"/>(s) it has.
        /// </summary>
        protected Port[] Ports;
        
        /// <summary>
        /// Stores the name of this <see cref="Shape"/>.
        /// </summary>
        private string _name;

        /// <summary>
        /// Stores the x-axis attribute of this <see cref="Shape"/>.
        /// </summary>
        private int _x;

        /// <summary>
        /// Stores the y-axis attribute of this <see cref="Shape"/>.
        /// </summary>
        private int _y;

        /// <summary>
        /// Stores the width attribute of this <see cref="Shape"/>.
        /// </summary>
        private int _width;

        /// <summary>
        /// Stores the height attribute of this <see cref="Shape"/>.
        /// </summary>
        private int _height;

        /// <summary>
        /// Stores a <see cref="bool"/> to decide whether this <see cref="Shape"/>
        /// is selected or not.
        /// </summary>
        private bool _isSelected;

        /// <summary>
        /// Generates a <see cref="Shape"/> instance.
        /// </summary>
        protected Shape()
        {
            ForeColor = Color.White;
            BackColor = Color.LightSlateGray;
            FontStyle = new Font(FontFamily.GenericSansSerif, 10);
            BorderWidth = 3;

            Ports = null;
            Shapes = null;

            _name = string.Empty;
            _isSelected = false;
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
            Combinations = new List<Combination>();
        }

        /// <summary>
        /// Generates a <see cref="Shape"/> instance with x-axis and y-axis
        /// attributes initialized.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        protected Shape(int x, int y)
        {
            ForeColor = Color.White;
            BackColor = Color.LightSlateGray;
            FontStyle = new Font(FontFamily.GenericSansSerif, 10);
            BorderWidth = 3;

            Ports = null;
            Shapes = null;

            _name = string.Empty;
            _isSelected = false;
            _x = x;
            _y = y;
            _width = 0;
            _height = 0;
            Combinations = new List<Combination>();
        }

        /// <summary>
        /// Generates a <see cref="Shape"/> instance with x-axis, y-axis, width
        /// and height attributes initialized.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        /// <param name="y">The y-axis value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        protected Shape(int x, int y, int width, int height)
        {
            ForeColor = Color.White;
            BackColor = Color.LightSlateGray;
            FontStyle = new Font(FontFamily.GenericSansSerif, 10);
            BorderWidth = 3;

            Ports = null;
            Shapes = null;

            _name = string.Empty;
            _isSelected = false;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            Combinations = new List<Combination>();
        }

        /// <summary>
        /// Adds a <see cref="Combination"/> to this <see cref="Shape"/>, which means that this
        /// <see cref="Shape"/> is bound to the given <see cref="Combination"/>.
        /// </summary>
        /// <param name="combination">
        /// The <see cref="Combination"/> this <see cref="Shape"/> will be bound to.
        /// </param>
        public void AddCombination(Combination combination)
        {
            Debug.Assert(combination != null);
            Combinations.Add(combination);
        }

        /// <summary>
        /// Removes the matched <see cref="Combination"/> from this <see cref="Shape"/>.
        /// </summary>
        /// <param name="combination">The specific <see cref="Combination"/> to be removed.</param>
        /// <remarks>
        /// Please be aware that the <see cref="Combination"/> itself will
        /// not remove this <see cref="Shape"/> on <see cref="Canvas"/> automatically.
        /// </remarks>
        public virtual void RemoveCombination(Combination combination)
        {
            Debug.Assert(combination != null);
            
            Combinations.Remove(combination);
        }

        /// <summary>
        /// Destroys all <see cref="Combination"/>s in this <see cref="Shape"/>.
        /// </summary>
        public virtual void DestroyAllCombinations()
        {
            Debug.Assert(Combinations != null);
            
            while(Combinations.Count > 0)
            {
                if(Combinations.Count >=1)
                {
                    Combinations[0].Destroy();
                    if (Combinations.Count == 1)
                    {
                        Combinations[0].Destroy();
                        break;
                    }
                }
            }
            
            //Combinations[0].Line.IsSelected = false;
        }

        /// <summary>
        /// Finds and gets a nearest <see cref="Port"/> from this <see cref="Shape"/>.
        /// </summary>
        /// <param name="p">The criteria <see cref="Port"/>.</param>
        /// <returns>Returns a nearest <see cref="Port"/> from this <see cref="Shape"/>.</returns>
        public virtual Port GetNearestPort(Point p)
        {
            Debug.Assert(Ports != null);

            Port resultPort = Ports[0];
            double distance = Ports[0].GetDistanceFrom(p);

            for (int i = 1; i < Ports.Length; i++)
            {
                Debug.Assert(Ports[i] != null);

                double currentDistance = Ports[i].GetDistanceFrom(p);
                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    resultPort = Ports[i];
                }
            }

            return resultPort;
        }

        /// <summary>
        /// Gets a certain <see cref="Port"/> from this <see cref="Shape"/> by a zero-based index.
        /// </summary>
        /// <param name="index">The index of the <see cref="Port"/>.</param>
        /// <returns>Returns the index-th <see cref="Port"/> from this <see cref="Shape"/>.</returns>
        public Port GetPort(int index)
        {
            Debug.Assert(Ports != null);
            Debug.Assert(index >= 0 && index < Ports.Length);
            Debug.Assert(Ports[index] != null);

            return Ports[index];
        }

        /// <summary>
        /// Gets a certain sub-<see cref="Shape"/> by a zero-based index.
        /// </summary>
        /// <param name="index">The index of the <see cref="Shape"/>.</param>
        /// <returns>Returns the index-th <see cref="Shape"/> contained by this <see cref="Shape"/>.</returns>
        public Shape GetShape(int index)
        {
            Debug.Assert(Shapes != null);
            Debug.Assert(index >= 0 && index < Shapes.Count);
            Debug.Assert(Shapes[index] != null);

            return Shapes[index];
        }

        /// <summary>
        /// Check if the given <see cref="Point"/> is covered by this
        /// <see cref="Shape"/> or not.
        /// </summary>
        /// <remarks>
        /// A covers B means that the position B is within the boundary of B.
        /// </remarks>
        /// <param name="p">The <see cref="Point"/> to be checked.</param>
        /// <returns>
        /// Returns <code>true</code> if the given <see cref="Point"/> is covered
        /// by this <see cref="Shape"/>; otherwise, returns <code>false</code>.
        /// </returns>
        public virtual bool IsCovers(Point p)
        {
            return
            (
               p.X > _x &&
               p.Y > _y &&
               p.X < _x + _width &&
               p.Y < _y + _height
            );
        }

        /// <summary>
        /// Check if this <see cref="Shape"/> is inside the area formed by
        /// the two given <see cref="Point"/>s.
        /// </summary>
        /// <param name="p1">First <see cref="Point"/> to form an area.</param>
        /// <param name="p2">Second <see cref="Point"/> to form an area.</param>
        /// <returns>
        /// Returns <code>true</code> if this <see cref="Shape"/> is within the
        /// area formed by the two given <see cref="Point"/>s; otherwise, returns
        /// <code>false</code>.
        /// </returns>
        public bool IsWithin(Point p1, Point p2)
        {
            Debug.Assert(p1 != null && p2 != null);

            int leftBoundary = Math.Min(p1.X, p2.X);
            int topBoundary = Math.Min(p1.Y, p2.Y);
            int rightBoundary = leftBoundary + Math.Abs(p1.X - p2.X);
            int bottomBoundary = topBoundary + Math.Abs(p1.Y - p2.Y);

            return (
                leftBoundary <= X &&
                topBoundary <= Y &&
                rightBoundary >= X + Width &&
                bottomBoundary >= Y + Height
            );
        }

        /// <summary>
        /// Moves this <see cref="Shape"/> by the given offsets.
        /// </summary>
        /// <param name="offsetX">The x-axis offset.</param>
        /// <param name="offsetY">The y-axis offset.</param>
        /// <remarks>
        /// This will update the <see cref="_x"/> and <see cref="_y"/> member of
        /// this <see cref="Shape"/>.
        /// </remarks>
        public virtual void Move(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
            for (int i = 0; i < Ports.Length; i++)
            {
                if (Ports[i].Movable)
                {
                    Ports[i].Move(offsetX, offsetY);

                }
            }
            if(Shapes!=null)
            {
                foreach (Shape shape in Shapes)
                {
                    shape.Move(offsetX, offsetY);
                }
            }
            
            //base.Move(offsetX, offsetY);
            

        }

        /// <summary>
        /// Performs a paint action. Paints itself using the given <see cref="Graphics"/> g.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        public virtual void Paint(Graphics g)
        {
            for (int i = 0; i < Ports.Length; i++)
            {
                Ports[i].Paint(g);
            }
        }

        /// <summary>
        /// Removes a contained <see cref="Shape"/> by a given index.
        /// </summary>
        /// <param name="index">The index number of <see cref="Shape"/> to be removed.</param>
        /// <returns>
        /// Returns the removed <see cref="Shape"/>. If the sub-<see cref="Shape"/> cannot be found
        /// inside this <see cref="Shape"/>, <code>null</code> will be returned.
        /// </returns>
        public Shape Remove(int index)
        {
            if (Shapes == null || Shapes.Count == 0) return null;

            Shape shapeToBeRemoved = Shapes[index];
            Shapes.RemoveAt(index);

            return shapeToBeRemoved;
        }

        /// <summary>
        /// Removes the first <see cref="Shape"/> contained by this <see cref="Shape"/>.
        /// </summary>
        /// <returns>
        /// Returns the removed <see cref="Shape"/>. If no <see cref="Shape"/> is contained by
        /// this <see cref="Shape"/>, <code>null</code> will be returned.
        /// </returns>
        public Shape RemoveFirst()
        {
            if (Shapes == null || Shapes.Count == 0) return null;
            
            Shape shapeToBeRemoved = Shapes[0];
            Shapes.RemoveAt(0);

            return shapeToBeRemoved;
        }

        /// <summary>
        /// Removes the last <see cref="Shape"/> contained by this <see cref="Shape"/>.
        /// </summary>
        /// <returns>
        /// Returns the removed <see cref="Shape"/>. If no <see cref="Shape"/> is contained by
        /// this <see cref="Shape"/>, <code>null</code> will be returned.
        /// </returns>
        public Shape RemoveLast()
        {
            if (Shapes == null || Shapes.Count == 0) return null;

            int lastIndex = Shapes.Count - 1;
            Shape shapeToBeRemoved = Shapes[lastIndex];
            Shapes.RemoveAt(lastIndex);

            return shapeToBeRemoved;
        }

        /// <summary>
        /// Sets the location of this <see cref="Shape"/> to the given x and y-axis value.
        /// </summary>
        /// <param name="x">The x-axis value of the new position.</param>
        /// <param name="y">The y-axis value of the new position.</param>
        public virtual void SetLocation(int x, int y)
        {
            Debug.Assert(Ports != null);

            int offsetX = x - X;
            int offsetY = y - Y;

            for (int i = 0; i < Ports.Length; i++)
            {
                Debug.Assert(Ports[i] != null);
                Ports[i].Move(offsetX, offsetY);
            }

            X = x;
            Y = y;
        }

        /// <summary>
        /// Sets the <see cref="Port"/> of this <see cref="Shape"/>.
        /// </summary>
        /// <param name="index">The index of <see cref="Port"/> contained by this <see cref="Shape"/>.</param>
        /// <param name="port">The instance of the new <see cref="Port"/>.</param>
        public virtual void SetPort(int index, Port port)
        {
            Debug.Assert(Ports != null);
            Debug.Assert(index >= 0 && index < Ports.Length);

            Ports[index] = port;
        }

        /// <summary>
        /// Sets the size to the given width and height.
        /// </summary>
        /// <param name="width">The value of width.</param>
        /// <param name="height">The value of height.</param>
        public virtual void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Sets the name of this <see cref="Shape"/>.
        /// </summary>
        /// <param name="name">The new name of this <see cref="Shape"/> to be updated to.</param>
        protected virtual void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _name = name;
            }
        }

        /// <summary>
        /// Set this <see cref="Shape"/> to the selected or unselected status.
        /// </summary>
        /// <param name="isSelected">
        /// The <seealso cref="bool"/> of the <see cref="_isSelected"/> member
        /// should be. <seealso cref="bool"/> for selected; <seealso cref="bool"/> or
        /// unselected.
        /// </param>
        protected virtual void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;

            for (int i = 0; i < Ports.Length; i++)
            {
                Ports[i].Visible = isSelected;
                Ports[i].Movable = isSelected;
            }
        }

        /// <summary>
        /// Gets the total count of the <see cref="Shape"/>s contained by
        /// this <see cref="Shape"/>.
        /// </summary>
        /// <returns></returns>
        private int GetShapesCount()
        {
            if (Shapes == null) return 0;

            return Shapes.Count;
        }

        /// <summary>
        /// Sets the x-axis position of this <see cref="Shape"/> to the given
        /// <seealso cref="int"/> value.
        /// </summary>
        /// <param name="x">
        /// The new x-axis value of this <see cref="Shape"/> should be.
        /// </param>
        private void SetX(int x)
        {
            _x = x;
        }

        /// <summary>
        /// Sets the y-axis position of this <see cref="Shape"/> to the given
        /// <seealso cref="int"/> value.
        /// </summary>
        /// <param name="y">
        /// The new y-axis value of this <see cref="Shape"/> should be.
        /// </param>
        private void SetY(int y)
        {
            _y = y;
        }

        /// <summary>
        /// Set the width of this <see cref="Shape"/> to the given <seealso cref="int"/> value.
        /// </summary>
        /// <param name="width">
        /// The new width value of this <see cref="Shape"/> should be.
        /// </param>
        private void SetWidth(int width)
        {
            _width = width;
        }

        /// <summary>
        /// Set the height of this <see cref="Shape"/> to the given <seealso cref="int"/> value.
        /// </summary>
        /// <param name="height">
        /// The new height value of this <see cref="Shape"/> should be.
        /// </param>
        private void SetHeight(int height)
        {
            _height = height;
        }
    }
}
