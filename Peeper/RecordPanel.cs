using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peeper {
	public partial class RecordPanel : UserControl {
		public RecordPanel() {
			InitializeComponent();
		}

		private void RecordPanel_Load(object sender, EventArgs e) {
			BackColor = Color.Fuchsia;	
			Location = new Point(1, 1);
			Size = new Size(Parent.Size.Width - 2, Parent.Size.Height - 2);
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
		}
	}
}