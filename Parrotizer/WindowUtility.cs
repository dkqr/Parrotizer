using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

// taken from here, had to change some things because hWnd was zero
// https://stackoverflow.com/a/67010648
static class WindowUtility {
    // very bad idea (i found out the hard way)
    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_NOZORDER = 0x0004;
    [StructLayout(LayoutKind.Sequential)]
    private struct Rect {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
    public struct Size {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size(int width, int height) {
            Width = width;
            Height = height;
        }
    }
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(HandleRef hWnd, out Rect lpRect);
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetConsoleWindow();
    public static Size GetWindowSize(IntPtr window) {
        if (!GetWindowRect(new HandleRef(null, window), out Rect rect))
            try {
                throw new Exception("Unable to get window rect!");
            } catch {

            }

        int width = rect.Right - rect.Left;
        int height = rect.Bottom - rect.Top;

        return new Size(width, height);
    }
    public static void SetPosition(int x, int y, IntPtr a) {
        // its sillying time >:)
        IntPtr hWnd = a;

        // If found, position it.
        if (hWnd != IntPtr.Zero) {
            // Move the windohw to (0,0) without changing its size or position
            // in the Z order.
            SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
        }
    }
}