using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Peeper {
	static class Program {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new PeeperForm());
		}

		public static void FFMPEG(string S) {
			//MessageBox.Show(S);
			ProcessStartInfo PSI = new ProcessStartInfo("ffmpeg.exe", S);
			Process.Start(PSI).WaitForExit();
		}

		public static void FFMPEG(string Fmt, params object[] Args) {
			FFMPEG(string.Format(Fmt, Args));
		}
	}
}