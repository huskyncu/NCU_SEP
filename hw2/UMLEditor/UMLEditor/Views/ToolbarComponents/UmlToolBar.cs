using System.Collections.Generic;
using System.Windows.Forms;
using UMLEditor.Modes;

namespace UMLEditor.Views.ToolbarComponents
{
    /// <summary>
    /// This <code>class</code> acts as a tool bar GUI at the left-hand-side of
    /// UML Editor main window. All functionality buttons are placed here for
    /// user to choose what he / she needs.
    /// </summary>
    public class UMLToolBar : ToolStrip
    {
        /// <summary>
        /// Stores all functionality buttons of <see cref="UMLToolBar"/>.
        /// </summary>
        private readonly List<UMLButton> _buttons = new List<UMLButton>();

        /// <summary>
        /// Generates an <see cref="UMLToolBar"/> instance.
        /// </summary>
        public UMLToolBar()
        {
            InitializeView();
            AddButtons();
        }

        /// <summary>
        /// Adds all functionality buttons onto toolbar panel.
        /// </summary>
        private void AddButtons()
        {
            SelectionButton selectionButton = new SelectionButton(new SelectMode(), this);
            Items.Add(selectionButton);
            _buttons.Add(selectionButton);

            AssociationLineButton associationLineButton = new AssociationLineButton(new AssociationLineMode(), this);
            Items.Add(associationLineButton);
            _buttons.Add(associationLineButton);

            GenerationLineButton generationLineButton = new GenerationLineButton(new GenerationLineMode(), this);
            Items.Add(generationLineButton);
            _buttons.Add(generationLineButton);

            CompositionLineButton compositionLineButton = new CompositionLineButton(new CompositionLineMode(), this);
            Items.Add(compositionLineButton);
            _buttons.Add(compositionLineButton);

            ClassButton classButton = new ClassButton(new ClassMode(), this);
            Items.Add(classButton);
            _buttons.Add(classButton);

            UseCaseButton useCaseButton = new UseCaseButton(new UseCaseMode(), this);
            Items.Add(useCaseButton);
            _buttons.Add(useCaseButton);

            selectionButton.PerformClick();
        }

        /// <summary>
        /// Check clicked button, unckeck the others.
        /// </summary>
        /// <param name="button"></param>
        public void SetFocusItem(UMLButton button)
        {
            UMLButton checkedButton = FindCheckedButton();
            
            if (checkedButton != null && !checkedButton.Name.Equals(button.Name))
            {
                UncheckAllButtons();
            }

            button.Checked = true;
        }

        /// <summary>
        /// Initializes the style itself.
        /// </summary>
        private void InitializeView()
        {
            BackColor = System.Drawing.Color.Transparent;
            Dock = DockStyle.Fill;
            GripStyle = ToolStripGripStyle.Hidden;
            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            Location = new System.Drawing.Point(0, 0);
            Name = "UMLToolBar";
            Padding = new Padding(0);
            RenderMode = ToolStripRenderMode.System;
            Size = new System.Drawing.Size(22, 487);
            TabIndex = 2;
            Text = "Toolbar";
        }

        /// <summary>
        /// Gets the checked <see cref="UMLButton"/>.
        /// </summary>
        /// <returns>Returns a <see cref="UMLButton"/> which is checked.</returns>
        private UMLButton FindCheckedButton()
        {
            foreach (UMLButton button in _buttons)
            {
                if (button.Checked) return button;
            }

            return null;
        }

        /// <summary>
        /// Uncheck all <see cref="UMLButton"/>s.
        /// </summary>
        private void UncheckAllButtons()
        {
            foreach (UMLButton button in _buttons)
            {
                button.Checked = false;
            }
        }
    }
}
