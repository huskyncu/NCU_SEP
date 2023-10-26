using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UMLEditor.Pseudo;
using UMLEditor.Shapes.ConnectionLines;
using UMLEditor.Views;

namespace UMLEditor.Shapes.BasicObjects
{
    /// <summary>
    /// This class inherits from the <see cref="Shape"/> class, used to combine,
    /// that is, group multiple <see cref="BasicObject"/>s into one <see cref="CompositionObject"/>.
    /// </summary>
    /// <remarks>
    /// This is a <code>sealed</code> class which means that no class can inhertis
    /// from it.
    /// </remarks>
    public sealed class CompositionObject : BasicObject
    {
        /// <summary>
        /// Generates an instance of <see cref="CompositionObject"/> object.
        /// </summary>
        public CompositionObject()
        {
            Shapes = new List<Shape>();
        }

        /// <summary>
        /// Adds a <see cref="Shape"/> into this group.
        /// </summary>
        /// <param name="shape"></param>
        public void Add(Shape shape)
        {
            Debug.Assert(shape != null);

            Shapes.Add(shape);
        }

        /// <summary>
        /// Clears out all <see cref="Combination"/>s from all <see cref="BasicObject"/>s
        /// in this group.
        /// </summary>
        /// <remarks>
        /// This method <code>override</code>s the <see cref="Shape.DestroyAllCombinations"/>
        /// without calling it.
        /// </remarks>
        public override void DestroyAllCombinations()
        {
            foreach (Shape shape in Shapes)
            {
                shape.DestroyAllCombinations();
            }
        }

        /// <summary>
        /// Finds and gets a nearest <see cref="Port"/> from this <see cref="CompositionObject"/>.
        /// </summary>
        /// <param name="p">The criteria <see cref="Port"/>.</param>
        /// <returns>Returns <code>null</code>.</returns>
        /// <remarks>
        /// Since a <see cref="CompositionObject"/> should not be bound to any <see cref="Line"/>,
        /// so we <code>override</code>s the <see cref="Shape.GetNearestPort"/> method and always
        /// returns <code>null</code>.
        /// </remarks>
        public override Port GetNearestPort(Point p)
        {
            return null;
        }

        public override bool IsCovers(Point p)
        {
            if (IsSelected) return base.IsCovers(p);

            foreach (Shape shape in Shapes)
            {
                if (shape.IsCovers(p)) return true;
            }

            return false;
        }
        
        /// <summary>
        /// Paints all sub-<see cref="BasicObject"/>s in this <see cref="CompositionObject"/>
        /// group. Also, paint the area formed by all sub-<see cref="BasicObject"/>.
        /// </summary>
        /// <param name="g">The <see cref="Graphics"/> to be used for painting.</param>
        /// <remarks>
        /// This method <code>override</code>s the <see cref="BasicObject.Paint"/> method
        /// without calling it.
        /// </remarks>
        public override void Paint(Graphics g)
        {
            foreach (Shape shape in Shapes)
            {
                shape.Paint(g);
            }

            if (IsSelected)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(50, 100, 100, 100)))
                {
                    g.FillRectangle(brush, X, Y, Width, Height);
                }

                using (Pen pen = new Pen(ForeColor))
                {
                    g.DrawRectangle(pen, X, Y, Width, Height);
                }
            }
        }

        /// <summary>
        /// Sets the location of all sub-<see cref="BasicObject"/>s in this <see cref="CompositionObject"/>
        /// to the given x and y-axis value.
        /// </summary>
        /// <param name="x">The x-axis value of the new position.</param>
        /// <param name="y">The y-axis value of the new position.</param>
        public override void SetLocation(int x, int y)
        {
            int originX = X;
            int originY = Y;
            base.SetLocation(x, y);

            foreach (Shape shape in Shapes)
            {
                shape.Move(x - originX, y - originY);
            }
        }

        /// <summary>
        /// Sets the name of all sub-<see cref="BasicObject"/>s in this <see cref="CompositionObject"/>.
        /// </summary>
        /// <param name="name">The new name of this <see cref="Shape"/> to be updated to.</param>
        protected override void SetName(string name)
        {
            foreach (Shape shape in Shapes)
            {
                shape.Name = name;
            }

            base.SetName(name);
        }

        /// <summary>
        /// Sets all sub-<see cref="BasicObject"/>s in this <see cref="CompositionObject"/> to
        /// the selected or unselected status.
        /// </summary>
        /// <param name="isSelected">
        /// The <seealso cref="bool"/> of the <see cref="_isSelected"/> member
        /// should be. <seealso cref="bool"/> for selected; <seealso cref="bool"/> or
        /// unselected.
        /// </param>
        protected override void SetSelected(bool isSelected)
        {
            if (Shapes.Count > 0)
            {
                foreach (Shape shape in Shapes)
                {
                    shape.IsSelected = isSelected;
                }

                base.SetSelected(isSelected);
            }
        }

        /// <summary>
        /// Updates the size of <see cref="CompositionObject"/> (group) object.
        /// </summary>
        public void UpdateSize()
        {
            if (Shapes.Count > 0)
            {
                Shape firstShape = Shapes[0];
                int left = firstShape.X;
                int top = firstShape.Y;
                int right = firstShape.X + firstShape.Width;
                int bottom = firstShape.Y + firstShape.Height;

                for (int i = 1; i < Shapes.Count; i++)
                {
                    Shape currentShape = Shapes[i];
                    left = Math.Min(left, currentShape.X);
                    top = Math.Min(top, currentShape.Y);
                    right = Math.Max(right, currentShape.X + currentShape.Width);
                    bottom = Math.Max(bottom, currentShape.Y + currentShape.Height);
                }

                base.SetLocation(left, top);
                SetSize(right - left, bottom - top);
            }
        }
    }
}
