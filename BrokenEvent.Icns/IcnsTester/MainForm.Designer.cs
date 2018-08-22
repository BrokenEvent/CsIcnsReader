namespace IcnsTester
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.odOpen = new System.Windows.Forms.OpenFileDialog();
      this.btnOpen = new System.Windows.Forms.Button();
      this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // odOpen
      // 
      this.odOpen.DefaultExt = "icns";
      this.odOpen.Filter = "ICNS image (*.icns)|*.icns";
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(12, 366);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 0;
      this.btnOpen.Text = "Open file";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // flowLayoutPanel
      // 
      this.flowLayoutPanel.AutoScroll = true;
      this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
      this.flowLayoutPanel.Location = new System.Drawing.Point(93, 0);
      this.flowLayoutPanel.Name = "flowLayoutPanel";
      this.flowLayoutPanel.Size = new System.Drawing.Size(535, 410);
      this.flowLayoutPanel.TabIndex = 1;
      // 
      // MainForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(628, 410);
      this.Controls.Add(this.flowLayoutPanel);
      this.Controls.Add(this.btnOpen);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "MainForm";
      this.Text = "Icns Tester";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog odOpen;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    private System.Windows.Forms.ToolTip toolTip;
  }
}

