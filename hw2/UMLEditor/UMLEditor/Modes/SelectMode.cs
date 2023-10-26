using System;
using System.Drawing;
using System.Windows.Forms;
using UMLEditor.Events;
using UMLEditor.Shapes;
using UMLEditor.Shapes.BasicObjects;
using UMLEditor.Views;

namespace UMLEditor.Modes
{
    /// <summary>
    /// Holds the operations for manipulating single and multiple <see cref="Shape"/>s
    /// selection when mosue events fired.
    /// </summary>
    /// <seealso cref="SelectedArea"/>
    public class SelectMode : Mode
    {
        /// <summary>
        /// Holds the <code>bool</code> which determines whether a <see cref="SelectedArea"/>
        /// formed or not.
        /// </summary>
        private bool _hasSelectArea;

        /// <summary>
        /// The <see cref="Point"/> which holds the initial mouse pressed position.
        /// </summary>
        private Point _mousePressedPoint;

        /// <summary>
        /// The <see cref="Point"/> which holds the current mouse position.
        /// </summary>
        private Point _currentMousePoint;

        /// <summary>
        /// Generates a <see cref="SelectMode"/> instance.
        /// </summary>
        /// <seealso cref="Mode()"/>
        public SelectMode()
        {
            _mousePressedPoint = new Point();
            _currentMousePoint = new Point();
            _hasSelectArea = false;
            ModeDescription = "Select:\n" +
                "Click on the object or use mouse to drag an area to select UML or Use case class(es).\n" +
                "An object is \"selected\" if its 4 connection ports are displayed.\n" +
                "On the other hand, when an object is not selected, the 4 connection ports will be hidden.";
        }

        /// <summary>
        /// Performs the mouse down event.
        /// If mouse is pressed on any <see cref="Shape"/> on <see cref="Canvas"/>, then set this
        /// <seealso cref="object"/> selected, otherwise, deselect all <see cref="Shape"/>s and
        /// forms a <see cref="SelectedArea"/>.
        /// </summary>
        /// <remarks>Also updates the position of <see cref="_currentMousePoint"/>.</remarks>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseDown"/>
        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            _mousePressedPoint = new Point(e.X, e.Y);
            _currentMousePoint = new Point(e.X, e.Y);
            Shape = GetPressedShape(_currentMousePoint);

            if (Shape != null)
            {
                if (!Shape.IsSelected) SingleSelect(Shape);
            }
            else
            {
                //Mouse pressed on blank field: deselect all shapes
                DeselectAll();
                //Not a single shape selected: prepare to form a selection area.
                Shape = new SelectedArea(e.X, e.Y);
                Canvas.AddShape(Shape);
                _hasSelectArea = true;
            }

            base.OnMouseDown(sender, e);
        }

        /// <summary>
        /// Performs the mouse drag event.
        /// If there is any selected <see cref="Shape"/>, move selected <see cref="Shape"/> by
        /// the offset information provided in the <see cref="MouseDragEventArgs"/>; otherwise,
        /// Updates the location and size of created <see cref="SelectedArea"/>.
        /// </summary>
        /// <remarks>Also updates the position of <see cref="_currentMousePoint"/>.</remarks>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseDrag"/>
        public override void OnMouseDrag(object sender, MouseDragEventArgs e)
        {
            if (_hasSelectArea)
            {
                //No shape selected means formed a selected area
                _currentMousePoint.X = e.X;
                _currentMousePoint.Y = e.Y;
                UpdateSelectedArea(Shape);
            }
            else
            {
                foreach (Shape shape in Canvas.SelectedShapes)
                {
                    shape.Move(e.OffsetX, e.OffsetY);
                }
            }

            base.OnMouseDrag(sender, e);
        }

        /// <summary>
        /// Performs the mouse up event.
        /// If the <see cref="SelectedArea"/> is previously created, select all <see cref="Shape"/>s
        /// within the area formed by the <see cref="SelectedArea"/>.
        /// </summary>
        /// <param name="sender">The <seealso cref="object"/> which triggers the event.</param>
        /// <param name="e">The <seealso cref="EventArgs"/> containing information of mouse.</param>
        /// <seealso cref="Mode.OnMouseUp"/>
        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_hasSelectArea)
            {
                Canvas.RemoveShape(Shape);
                DeselectAll();
                MultipleSelect(Shape);
                _hasSelectArea = false;
                Shape = null;
            }
            else
            {
                Shape pressedShape = GetPressedShape(new Point(e.X, e.Y));
                if (pressedShape == null) DeselectAll();
            }

            base.OnMouseUp(sender, e);
        }

        /// <summary>
        /// Deselect all <see cref="Shape"/>s on the <see cref="Canvas"/>.
        /// </summary>
        private void DeselectAll()
        {
            foreach (Shape shape in Canvas.SelectedShapes)
            {
                shape.IsSelected = false;
            }
        }

        /// <summary>
        /// Gets the top <see cref="Shape"/> which is pressed by mouse.
        /// The <see cref="Shape"/> is determined as pressed if the <see cref="Shape"/>
        /// covers (contains) the given <see cref="Point"/>.
        /// </summary>
        /// <param name="point">
        /// The <see cref="Point"/> which should be within the selected <see cref="Shape"/>.
        /// </param>
        /// <returns>
        /// Returns the pressed <see cref="Shape"/>. If no <see cref="Shape"/> is determined
        /// as pressed, then <code>null</code> will be returned.
        /// </returns>
        private Shape GetPressedShape(Point point)
        {
            for (int i = Canvas.GetShapeCount() - 1; i >= 0; i--)
            {
                Shape currentShape = Canvas.GetShape(i);
                if (currentShape.IsCovers(point))
                {
                    return currentShape;
                }
            }

            return null;
        }

        /// <summary>
        /// Selects all <see cref="Shape"/>s which are within the area covered by
        /// the <see cref="SelectedArea"/>.
        /// </summary>
        /// <param name="selectedArea">The selection area.</param>
        private void MultipleSelect(Shape selectedArea)
        {
            Point p1 = new Point(selectedArea.X, selectedArea.Y);
            Point p2 = new Point(selectedArea.X + selectedArea.Width, selectedArea.X + selectedArea.Height);

            foreach (Shape shape in Canvas.Shapes)
            {
                if (shape.IsWithin(p1, p2))
                {
                    Canvas.RemoveShape(shape);
                    Canvas.AddShape(shape);
                    shape.IsSelected = true;
                }
            }
        }

        /// <summary>
        /// Select the given <see cref="Shape"/> and deselects all other <see cref="Shape"/>s.
        /// </summary>
        /// <param name="shape">The <see cref="Shape"/> to be selected.</param>
        private void SingleSelect(Shape shape)
        {
            DeselectAll();
            Canvas.RemoveShape(shape);
            Canvas.AddShape(shape);
            shape.IsSelected = true;
        }

        /// <summary>
        /// Updates the location and size of <see cref="SelectedArea"/>.
        /// </summary>
        /// <param name="selectedArea">The <see cref="SelectedArea"/> to be updated.</param>
        private void UpdateSelectedArea(Shape selectedArea)
        {
            int left , top, width, height;
            left = Math.Min(_mousePressedPoint.X, _currentMousePoint.X);
            top = Math.Min(_mousePressedPoint.Y, _currentMousePoint.Y);
            width = Math.Abs(_currentMousePoint.X - _mousePressedPoint.X);
            height = Math.Abs(_currentMousePoint.Y - _mousePressedPoint.Y);
           
            
            ///origin
            //int left = _mousePressedPoint.X;
            //int top = _mousePressedPoint.Y;
            //int width = _currentMousePoint.X - _mousePressedPoint.X;
            //int height = _currentMousePoint.Y - _mousePressedPoint.Y;

            selectedArea.SetLocation(left, top);
            selectedArea.SetSize(width, height);
        }
    }
}
