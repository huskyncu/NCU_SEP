using MetroFramework.Forms;
using UMLEditor.Views;
using UMLEditor.Views.ToolbarComponents;

namespace UMLEditor
{
    public partial class UMLEditorForm : MetroForm
    {
        public UMLEditorForm()
        {
            InitializeComponent();
            MenuBarPanel.Controls.Add(new MenuBar());
            ToolsPanel.Controls.Add(new UMLToolBar());
            CanvasPanel.Controls.Add(Canvas.GetInstance());
        }
    }
}
