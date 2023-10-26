using System.Drawing;
using System.Windows.Forms;
using UMLEditor.Views.ContextMenuComponents;
using UMLEditor.Views.ContextMenuComponents.EditContextMenu;
using UMLEditor.Views.ContextMenuComponents.FileContextMenu;

namespace UMLEditor.Views
{
    /// <summary>
    /// This <code>class</code> initializes the main menu bar of UML.
    /// </summary>
    public class MenuBar : MenuStrip
    {
        /// <summary>
        /// Gets the dark theme Metro <seealso cref="Color"/>.
        /// </summary>
        public static readonly Color MetroDarkThemeColor = Color.FromArgb(19, 19, 19);

        /// <summary>
        /// Initializes style of menu bar.
        /// </summary>
        public MenuBar()
        {
            BackColor = MetroDarkThemeColor;
            Dock = DockStyle.Fill;
            Location = new Point(0, 5);
            Name = "MenuBar";
            Padding = new Padding(0, 2, 0, 2);
            Size = new Size(760, 23);
            TabIndex = 2;
            Text = "MenuBar";

            InitializeContextMenus();
        }

        /// <summary>
        /// Initializes all items on menu bar.
        /// </summary>
        private void InitializeContextMenus()
        {
            UMLMenuItem fileMenu = new UMLMenuItem("File");
            FileContextMenu fileContextMenu = new FileContextMenu();
            fileMenu.DropDown = fileContextMenu;
            Items.Add(fileMenu);

            UMLMenuItem editMenu = new UMLMenuItem("Edit");
            EditContextMenu editContextMenu = new EditContextMenu();
            editMenu.DropDown = editContextMenu;
            Items.Add(editMenu);
        }
    }
}
