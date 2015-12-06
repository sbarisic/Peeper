using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using ThreadState = System.Threading.ThreadState;
using SharpAvi;
using SharpAvi.Output;
using SharpAvi.Codecs;

namespace Peeper {
	public partial class PeeperForm : Form {
		Size OriginalMaxSize, OriginalMinSize;
		Point RecorderOffset;

		public PeeperForm() {
			InitializeComponent();
		}

		private void PeeperForm_Load(object sender, EventArgs e) {
			const int ButtonHeight = 25;
			const int RightMargin = 70;
			const int ButtonMargins = 3;

			OriginalMaxSize = MaximumSize;
			OriginalMinSize = MinimumSize;

			TopMost = true;
			TransparencyKey = Color.Fuchsia;
			RecordContainer.Location = new Point(0, 0);
			RecordContainer.Size = new Size(ClientSize.Width - RightMargin, ClientSize.Height);

			Control[] Controls = new Control[] { RecButton, ExitButton, FpsUpDown, WebmCheckBox };

			for (int i = 0; i < Controls.Length; i++) {
				Controls[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
				Controls[i].Size = new Size(RightMargin - ButtonMargins * 2, ButtonHeight);
				Controls[i].Location = new Point(ClientSize.Width - Controls[i].Size.Width - ButtonMargins,
					i * ButtonHeight + i * ButtonMargins);
			}

			RecorderOffset = PointToScreen(RecordPanel.Location).Subtract(DesktopLocation);
			Text = string.Format("Peeper {0}x{1}", RecordPanel.Size.Width, RecordPanel.Size.Height);
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Text = string.Format("Peeper {0}x{1}", RecordPanel.Size.Width, RecordPanel.Size.Height);
		}

		void UseRecButton(Action A) {
			RecButton.Enabled = false;
			A();
			RecButton.Enabled = true;
		}

		bool AbortRecording;
		Thread RecordThread;

		private void RecButton_Click(object sender, EventArgs e) {
			UseRecButton(() => {
				if (RecordThread != null) {
					AbortRecording = true;
					while (RecordThread.ThreadState == ThreadState.Running)
						Thread.Sleep(10);
					RecordThread = null;

					WebmCheckBox.Enabled = true;
					FpsUpDown.Enabled = true;
					MaximizeBox = MinimizeBox = true;
					MaximumSize = OriginalMaxSize;
					MinimumSize = OriginalMinSize;
					RecButton.Text = "Rec";
				} else {
					AbortRecording = false;
					MaximizeBox = MinimizeBox = false;
					MaximumSize = MinimumSize = Size;
					FpsUpDown.Enabled = false;
					WebmCheckBox.Enabled = false;

					RecordThread = new Thread(Record);
					RecordThread.Start();
					RecButton.Text = "Stop";
				}
			});
		}

		void Record() {
			int FrameRate = (int)FpsUpDown.Value;
			Size RSize = RecordPanel.Size;

			int RndNum = new Random().Next();
			string OutFile = Path.GetFullPath(string.Format("rec_{0}.avi", RndNum));
			string OutFileCompressed = Path.GetFullPath(string.Format("rec_{0}.webm", RndNum));
			AviWriter Writer = new AviWriter(OutFile);
			Writer.FramesPerSecond = FrameRate;
			Writer.EmitIndex1 = true;

			IAviVideoStream VStream = Writer.AddVideoStream(RSize.Width, RSize.Height, BitsPerPixel.Bpp24);
			VStream.Codec = KnownFourCCs.Codecs.Uncompressed;
			VStream.BitsPerPixel = BitsPerPixel.Bpp24;

			Bitmap Bmp = new Bitmap(RSize.Width, RSize.Height);
			Graphics G = Graphics.FromImage(Bmp);

			Stopwatch SWatch = new Stopwatch();
			SWatch.Start();

			while (!AbortRecording) {
				G.CopyFromScreen(DesktopLocation.Add(RecorderOffset), Point.Empty, RSize);
				//G.DrawString("Text Embedding", SystemFonts.CaptionFont, Brushes.Red, new PointF(0, 0));
				Bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
				byte[] Data = Bmp.ToByteArray();
				VStream.WriteFrame(true, Data, 0, Data.Length);
				while ((float)SWatch.ElapsedMilliseconds / 1000 < 1.0f / FrameRate)
					;
				SWatch.Restart();
			}

			G.Dispose();
			Writer.Close();

			if (WebmCheckBox.Checked) {
				Program.FFMPEG("-i \"{0}\" -c:v libvpx -b:v 1M -c:a libvorbis \"{1}\"", OutFile, OutFileCompressed);
				File.Delete(OutFile);
			}
		}

		private void ExitButton_Click(object sender, EventArgs e) {
			Close();
		}
	}
}