using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using BrokenEvent.LibIcns;

namespace IcnsTester
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      odOpen.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Demo");

      if (odOpen.ShowDialog(this) != DialogResult.OK)
        return;

      List<IcnsImage> images = IcnsImageParser.GetImages(odOpen.FileName);
      flowLayoutPanel.Controls.Clear();

      foreach (IcnsImage image in images)
      {
        if (image.Bitmap == null)
          continue;

        PictureBox box = new PictureBox();
        box.Size = new Size(image.Type.Width, image.Type.Height);
        box.Image = image.Bitmap;
        toolTip.SetToolTip(box, image.Type.Width + "x" + image.Type.Height + " bpp: " + image.Type.BitsPerPixel);

        flowLayoutPanel.Controls.Add(box);
      }
    }
  }
}
