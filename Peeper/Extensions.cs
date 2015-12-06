using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace Peeper {
	static class Extensions {
		/*public static byte[] ToByteArray(this Image Img, ImageFormat Fmt) {
			using (MemoryStream MS = new MemoryStream()) {
				Img.Save(MS, Fmt);
				return MS.ToArray();
			}
		}*/

		public static byte[] ToByteArray(this Bitmap Img, PixelFormat PFmt = PixelFormat.Format24bppRgb) {
			BitmapData BmpData = Img.LockBits(new Rectangle(Point.Empty, Img.Size), ImageLockMode.ReadOnly, PFmt);
			int Len = BmpData.Stride * BmpData.Height;
			byte[] Bytes = new byte[Len];
			Marshal.Copy(BmpData.Scan0, Bytes, 0, Len);
			Img.UnlockBits(BmpData);
			return Bytes;
		}

		public static Point Add(this Point A, Point B) {
			return new Point(A.X + B.X, A.Y + B.Y);
		}

		public static Point Subtract(this Point A, Point B) {
			return new Point(A.X - B.X, A.Y - B.Y);
		}
	}
}