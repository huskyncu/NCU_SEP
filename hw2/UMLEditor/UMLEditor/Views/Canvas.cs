using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UMLEditor.Events;
using UMLEditor.Modes;
using UMLEditor.Shapes;

namespace UMLEditor.Views
{
    /// <summary>
    /// This class acts as a container of all <see cref="Shape"/>s and a
    /// event dispatcher.
    /// </summary>
    /// <remarks>
    /// The <see cref="Canvas"/> <code>class</code> is responsible of telling 
    /// <see cref="Shape"/>s to redraw themselves while needed, also is responsible
    /// of monitoring mouse events and dispatch the event from an appropriate <see cref="Mode"/>.
    /// </remarks>
    public class Canvas : Panel, IMouseEvents
    {
        /// <summary>
        /// Customized <see cref="EventHandler"/> for mouse events.
        /// </summary>
        public MouseDragEventHandler MouseDrag;

        /// <summary>
        /// Gets or Sets the current <see cref="Mode"/>.
        /// </summary>
        /// <remarks>
        /// Facade of <see cref="_currentMode"/>.
        /// </remarks>
        public Mode CurrentMode
        {
            get { return _currentMode; }
            set { SetMode(value); }
        }

        /// <summary>
        /// Gets all selected <see cref="Shape"/>s.
        /// </summary>
        public Shape[] SelectedShapes { get { return GetSelectedShapes(); } }

        /// <summary>
        /// Gets all existing <see cref="Shape"/>s.
        /// </summary>
        /// <remarks>
        /// Facade of <see cref="_shapes"/>. Only gives <code>array</code>s instead of
        /// providing the modifiable <code>List</code>.
        /// </remarks>
        public Shape[] Shapes { get { return _shapes.ToArray(); } }

        /// <summary>
        /// Gets the <see cref="Shape"/> which will be painted on the top of <see cref="Canvas"/>.
        /// </summary>
        public Shape TopShape { get { return GetTopShape(); } }

        /// <summary>
        /// Holds the <code>static</code> <see cref="Canvas"/> singleton object.
        /// </summary>
        private static Canvas _canvas;

        /// <summary>
        /// Holds the current <see cref="Mode"/>.
        /// </summary>
        private Mode _currentMode;

        /// <summary>
        /// Customized <seealso cref="MouseEventArgs"/> for storing mouse information
        /// while the mouse drag event is triggered.
        /// </summary>
        private MouseDragEventArgs _dragEventArgs;

        /// <summary>
        /// Determines whether the mouse is pressing on the <see cref="Canvas"/> or not.
        /// </summary>
        private bool _pressed;

        /// <summary>
        /// Holds all existing <see cref="Shape"/>s.
        /// </summary>
        private List<Shape> _shapes;

        /// <summary>
        /// Creates a <see cref="Canvas"/> instance.
        /// </summary>
        private Canvas()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.Black;
            BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
            Paint += Repaint;
            _currentMode = null;
            _dragEventArgs = null;
            _pressed = false;
            _shapes = new List<Shape>();
            InitializeMouseEvents();
        }

        /// <summary>
        /// Adds a <see cref="Shape"/> into <see cref="Canvas"/>.
        /// </summary>
        /// <param name="shape">The <see cref="Shape"/> to be added.</param>
        /// <returns>Returns the added <see cref="Shape"/>.</returns>
        public Shape AddShape(Shape shape)
        {
            Debug.Assert(shape != null);
            _shapes.Add(shape);
            return shape;
        }

        /// <summary>
        /// Retrieves the singleton <see cref="Canvas"/> object.
        /// </summary>
        /// <returns>Returns an instance of <see cref="Canvas"/> object.</returns>
        public static Canvas GetInstance()
        {
            if (_canvas == null)
            {
                _canvas = new Canvas();
            }

            return _canvas;
        }

        /// <summary>
        /// Gets a specific <see cref="Shape"/> with given index.
        /// </summary>
        /// <param name="index">The index of <see cref="Shape"/>.</param>
        /// <returns>Returns the index-th <see cref="Shape"/>.</returns>
        public Shape GetShape(int index)
        {
            Debug.Assert(_shapes != null);
            Debug.Assert(index >= 0 && index < _shapes.Count);

            return _shapes[index];
        }

        /// <summary>
        /// Gets the total count of <see cref="Shape"/>.
        /// </summary>
        /// <returns>
        /// Returns an <seealso cref="int"/> representing the total count of <see cref="Shape"/>.
        /// </returns>
        public int GetShapeCount()
        {
            Debug.Assert(_shapes != null);
            return _shapes.Count;
        }

        /// <summary>
        /// Handles the mouse click event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseClick(object sender, MouseEventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseClick(sender, e);
        }

        /// <summary>
        /// Handles the mouse double click event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseDoubleClick(sender, e);
        }

        /// <summary>
        /// Handles the mouse down event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Also initializes the customized mouse drag event.</remarks>
        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right)) return;

            // Customized mouse drag event.
            _dragEventArgs = new MouseDragEventArgs(e.Button, e.Clicks, e.X, e.Y, 0, 0, e.Delta);
            _pressed = true;

            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseDown(sender, e);
        }

        /// <summary>
        /// Handles the mouse drag event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Customized mouse drag event.</remarks>
        public void OnMouseDrag(object sender, MouseDragEventArgs e)
        {
            _currentMode.OnMouseDrag(sender, e);
        }

        /// <summary>
        /// Handles the mouse entered event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseEnter(object sender, EventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseEnter(sender, e);
        }

        /// <summary>
        /// Handles the mouse hover event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseHover(object sender, EventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseHover(sender, e);
        }

        /// <summary>
        /// Handles the mouse leave event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseLeave(object sender, EventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseLeave(sender, e);
        }

        /// <summary>
        /// Handles the mouse move event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>
        /// If the <see cref="_pressed"/> is <code>true</code>, customized <see cref="OnMouseDrag"/>
        /// event handler will be fired, customized <see cref="MouseEventArgs"/> containing mouse
        /// drag information will be generated and passed to the <see cref="OnMouseDrag"/> handler.
        /// </remarks>
        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            Debug.Assert(_currentMode != null);

            if (_pressed)
            {
                // Customized mouse drag event.
                int offsetX = e.X - _dragEventArgs.X;
                int offsetY = e.Y - _dragEventArgs.Y;
                _dragEventArgs = new MouseDragEventArgs(e.Button, e.Clicks, e.X, e.Y, offsetX, offsetY, e.Delta);
                _currentMode.OnMouseDrag(sender, _dragEventArgs);
            }
            else
            {
                _currentMode.OnMouseMove(sender, e);
            }
        }

        /// <summary>
        /// Handles the mouse up event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <remarks>Also finishes the mouse drag event.</remarks>
        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            // Customized mouse drag event.
            _pressed = false;
            _dragEventArgs = null;

            Debug.Assert(_currentMode != null);

            if (e.Button.Equals(MouseButtons.Right)) return;

            _currentMode.OnMouseUp(sender, e);
        }

        /// <summary>
        /// Handles the mouse wheel event and triggers the corresponding <see cref="Mode"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        public void OnMouseWheel(object sender, MouseEventArgs e)
        {
            Debug.Assert(_currentMode != null);
            _currentMode.OnMouseWheel(sender, e);
        }

        /// <summary>
        /// Removes a specific <see cref="Shape"/> with given index.
        /// </summary>
        /// <param name="index">The index of <see cref="Shape"/>.</param>
        /// <returns>Returns the removed <see cref="Shape"/>.</returns>
        public Shape RemoveShape(int index)
        {
            Debug.Assert(_shapes != null);
            Debug.Assert(index >= 0 && index < _shapes.Count);

            Shape shapeToBeRemoved = _shapes[index];
            _shapes.RemoveAt(index);
            return shapeToBeRemoved;
        }

        /// <summary>
        /// Removes the given <see cref="Shape"/> from <see cref="Canvas"/>.
        /// </summary>
        /// <param name="shape">The <see cref="Shape"/> to be removed.</param>
        /// <returns>Returns the removed <see cref="Shape"/>.</returns>
        public bool RemoveShape(Shape shape)
        {
            Debug.Assert(_shapes != null);
            
            return _shapes.Remove(shape);
        }

        /// <summary>
        /// Removes the last (top) <see cref="Shape"/>.
        /// </summary>
        /// <returns>Returns the removed <see cref="Shape"/>.</returns>
        public Shape RemoveLastShape()
        {
            Debug.Assert(_shapes != null);

            if (_shapes.Count == 0) return null;

            int lastIndex = _shapes.Count - 1;
            Shape shapeToBeRemoved = _shapes[lastIndex];
            _shapes.RemoveAt(lastIndex);

            return shapeToBeRemoved;
        }

        /// <summary>
        /// Removes all <see cref="Shape"/>s.
        /// </summary>
        public void RemoveAll()
        {
            _shapes.Clear();
        }

        /// <summary>
        /// Gets all selected <see cref="Shape"/>s.
        /// </summary>
        /// <returns>
        /// Returns an <seealso cref="Array"/> containing all selected <see cref="Shape"/>s.
        /// </returns>
        private Shape[] GetSelectedShapes()
        {
            Debug.Assert(_shapes != null);

            List<Shape> shapes = new List<Shape>();

            foreach (Shape shape in _shapes)
            {
                if (shape.IsSelected)
                {
                    shapes.Add(shape);
                }
            }

            return shapes.ToArray();
        }

        /// <summary>
        /// Gets <see cref="Shape"/> which will be painted on top of all <see cref="Shape"/>s.
        /// </summary>
        /// <returns>Returns the top <see cref="Shape"/>.</returns>
        private Shape GetTopShape()
        {
            Debug.Assert(_shapes != null);

            if (_shapes.Count == 0) return null;

            return _shapes[_shapes.Count - 1];
        }

        /// <summary>
        /// Initializes and binds event handlers.
        /// </summary>
        private void InitializeMouseEvents()
        {
            MouseClick += OnMouseClick;
            MouseDoubleClick += OnMouseDoubleClick;
            MouseDown += OnMouseDown;
            MouseDrag += OnMouseDrag;
            MouseEnter += OnMouseEnter;
            MouseHover += OnMouseHover;
            MouseLeave += OnMouseLeave;
            MouseMove += OnMouseMove;
            MouseUp += OnMouseUp;
            MouseWheel += OnMouseWheel;
        }

        /// <summary>
        /// Repaints itself.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> that triggers the repaint event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="PaintEventArgs"/> containing paint event information.
        /// </param>
        private void Repaint(object sender, PaintEventArgs e)
        {
            Debug.Assert(_shapes != null);

            using (Pen p = new Pen(Color.FromArgb(60, 60, 60), 1))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1));
            }

            Graphics g = e.Graphics;

            if (_shapes.Count > 0)
            {
                for (int i = 0; i < _shapes.Count; i++)
                {
                    _shapes[i].Paint(g);
                }
            }
        }

        /// <summary>
        /// Set the <see cref="_currentMode"/> to the given <see cref="Mode"/>.
        /// </summary>
        /// <param name="mode">The <see cref="Mode"/> to be set.</param>
        private void SetMode(Mode mode)
        {
            Debug.Assert(mode != null);
            _currentMode = mode;
        }
    }
}
