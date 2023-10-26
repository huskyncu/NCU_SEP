using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace UMLEditor.Views.Dialogs
{
    /// <summary>
    /// Displays the beautiful rename dialog GUI to user, holding
    /// the user input for next operation.
    /// </summary>
    public partial class RenameDialog : MetroForm
    {
        /// <summary>
        /// Gets the input name.
        /// </summary>
        public string ObjectName { get; private set; }

        /// <summary>
        /// Generates a <see cref="RenameDialog"/> instance.
        /// </summary>
        public RenameDialog()
        {
            InitializeComponent();
            ObjectName = string.Empty;
        }

        /// <summary>
        /// Disables the <see cref="OkButton"/> if text in <see cref="Input"/>
        /// is empty; otherwise, enables the <see cref="OkButton"/>.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> which fires this event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> which contains information of event.
        /// </param>
        private void Input_TextChanged(object sender, EventArgs e)
        {
            ObjectName = Input.Text;
            OkButton.Enabled = !string.IsNullOrEmpty(ObjectName);
        }

        /// <summary>
        /// Triggers the click event of <see cref="OkButton"/> if the "Enter" key
        /// is pressed on the <see cref="Input"/>.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> which fires this event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> which contains information of event.
        /// </param>
        private void Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                OkButton.PerformClick();
            }
        }

        /// <summary>
        /// Completes and close the rename dialog if the input name is valid.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> which fires this event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> which contains information of event.
        /// </param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ObjectName != string.Empty)
            {
                Close();
            }
        }

        /// <summary>
        /// Cancels and close the rename dialog.
        /// </summary>
        /// <param name="sender">
        /// The <seealso cref="object"/> which fires this event.
        /// </param>
        /// <param name="e">
        /// The <seealso cref="EventArgs"/> which contains information of event.
        /// </param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
