namespace UMLEditor
{
    partial class UMLEditorForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UMLEditorForm));
            this.BasePanel = new MetroFramework.Controls.MetroPanel();
            this.MainPanel = new MetroFramework.Controls.MetroPanel();
            this.WorkspacePanel = new MetroFramework.Controls.MetroPanel();
            this.CanvasPanel = new MetroFramework.Controls.MetroPanel();
            this.ToolsPanel = new MetroFramework.Controls.MetroPanel();
            this.MenuBarPanel = new MetroFramework.Controls.MetroPanel();
            this.FileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BasePanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.WorkspacePanel.SuspendLayout();
            this.FileContextMenu.SuspendLayout();
            this.EditContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasePanel
            // 
            this.BasePanel.Controls.Add(this.MainPanel);
            this.BasePanel.Controls.Add(this.MenuBarPanel);
            this.BasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasePanel.HorizontalScrollbarBarColor = true;
            this.BasePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.BasePanel.HorizontalScrollbarSize = 10;
            this.BasePanel.Location = new System.Drawing.Point(20, 60);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(760, 520);
            this.BasePanel.Style = MetroFramework.MetroColorStyle.Black;
            this.BasePanel.TabIndex = 1;
            this.BasePanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BasePanel.VerticalScrollbarBarColor = true;
            this.BasePanel.VerticalScrollbarHighlightOnWheel = false;
            this.BasePanel.VerticalScrollbarSize = 10;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.WorkspacePanel);
            this.MainPanel.Controls.Add(this.ToolsPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.HorizontalScrollbarBarColor = true;
            this.MainPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.MainPanel.HorizontalScrollbarSize = 10;
            this.MainPanel.Location = new System.Drawing.Point(0, 33);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(760, 487);
            this.MainPanel.Style = MetroFramework.MetroColorStyle.Black;
            this.MainPanel.TabIndex = 3;
            this.MainPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MainPanel.VerticalScrollbarBarColor = true;
            this.MainPanel.VerticalScrollbarHighlightOnWheel = false;
            this.MainPanel.VerticalScrollbarSize = 10;
            // 
            // WorkspacePanel
            // 
            this.WorkspacePanel.Controls.Add(this.CanvasPanel);
            this.WorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspacePanel.HorizontalScrollbarBarColor = true;
            this.WorkspacePanel.HorizontalScrollbarHighlightOnWheel = false;
            this.WorkspacePanel.HorizontalScrollbarSize = 10;
            this.WorkspacePanel.Location = new System.Drawing.Point(22, 0);
            this.WorkspacePanel.Name = "WorkspacePanel";
            this.WorkspacePanel.Size = new System.Drawing.Size(738, 487);
            this.WorkspacePanel.Style = MetroFramework.MetroColorStyle.Black;
            this.WorkspacePanel.TabIndex = 3;
            this.WorkspacePanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WorkspacePanel.VerticalScrollbarBarColor = true;
            this.WorkspacePanel.VerticalScrollbarHighlightOnWheel = false;
            this.WorkspacePanel.VerticalScrollbarSize = 10;
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CanvasPanel.HorizontalScrollbarBarColor = true;
            this.CanvasPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.CanvasPanel.HorizontalScrollbarSize = 10;
            this.CanvasPanel.Location = new System.Drawing.Point(0, 0);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CanvasPanel.Size = new System.Drawing.Size(738, 487);
            this.CanvasPanel.Style = MetroFramework.MetroColorStyle.Black;
            this.CanvasPanel.TabIndex = 3;
            this.CanvasPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CanvasPanel.VerticalScrollbarBarColor = true;
            this.CanvasPanel.VerticalScrollbarHighlightOnWheel = false;
            this.CanvasPanel.VerticalScrollbarSize = 10;
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolsPanel.HorizontalScrollbarBarColor = true;
            this.ToolsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ToolsPanel.HorizontalScrollbarSize = 10;
            this.ToolsPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(22, 487);
            this.ToolsPanel.Style = MetroFramework.MetroColorStyle.Black;
            this.ToolsPanel.TabIndex = 2;
            this.ToolsPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToolsPanel.VerticalScrollbarBarColor = true;
            this.ToolsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ToolsPanel.VerticalScrollbarSize = 10;
            // 
            // MenuBarPanel
            // 
            this.MenuBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuBarPanel.HorizontalScrollbarBarColor = true;
            this.MenuBarPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.MenuBarPanel.HorizontalScrollbarSize = 10;
            this.MenuBarPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MenuBarPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuBarPanel.Name = "MenuBarPanel";
            this.MenuBarPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.MenuBarPanel.Size = new System.Drawing.Size(760, 33);
            this.MenuBarPanel.Style = MetroFramework.MetroColorStyle.Black;
            this.MenuBarPanel.TabIndex = 2;
            this.MenuBarPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MenuBarPanel.VerticalScrollbarBarColor = true;
            this.MenuBarPanel.VerticalScrollbarHighlightOnWheel = false;
            this.MenuBarPanel.VerticalScrollbarSize = 10;
            // 
            // FileContextMenu
            // 
            this.FileContextMenu.BackColor = System.Drawing.Color.Transparent;
            this.FileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.FileContextMenu.Name = "FileContextMenu";
            this.FileContextMenu.Size = new System.Drawing.Size(101, 48);
            this.FileContextMenu.Style = MetroFramework.MetroColorStyle.Black;
            this.FileContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.ToolTipText = "Create a brand new sheet";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editToolStripMenuItem.Text = "Exit";
            this.editToolStripMenuItem.ToolTipText = "Exit the UML Editor program";
            // 
            // EditContextMenu
            // 
            this.EditContextMenu.BackColor = System.Drawing.Color.Black;
            this.EditContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.ungroupToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.EditContextMenu.Name = "EditContextMenu";
            this.EditContextMenu.Size = new System.Drawing.Size(126, 92);
            this.EditContextMenu.Style = MetroFramework.MetroColorStyle.Black;
            this.EditContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // ungroupToolStripMenuItem
            // 
            this.ungroupToolStripMenuItem.Name = "ungroupToolStripMenuItem";
            this.ungroupToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.ungroupToolStripMenuItem.Text = "Ungroup";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // UMLEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.BasePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "UMLEditorForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "UML Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BasePanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.WorkspacePanel.ResumeLayout(false);
            this.FileContextMenu.ResumeLayout(false);
            this.EditContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel BasePanel;
        private MetroFramework.Controls.MetroPanel MainPanel;
        private MetroFramework.Controls.MetroPanel WorkspacePanel;
        private MetroFramework.Controls.MetroPanel CanvasPanel;
        private MetroFramework.Controls.MetroPanel MenuBarPanel;
        private MetroFramework.Controls.MetroContextMenu FileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu EditContextMenu;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ungroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel ToolsPanel;
    }
}

