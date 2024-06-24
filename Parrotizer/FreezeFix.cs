using System.Runtime.InteropServices;


namespace FreezeFix {
    class FreezeFix {
        // Taken from https://stackoverflow.com/questions/39250218/code-stops-executing-when-a-user-clicks-on-the-console-window
        // from this comment https://stackoverflow.com/a/39250918
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out uint mode);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr handle, uint mode);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(uint handle);

        const uint ENABLE_PROCESSED_INPUT = 0x0001;
        const uint ENABLE_LINE_INPUT = 0x0002;
        const uint ENABLE_ECHO_INPUT = 0x0004;
        const uint ENABLE_WINDOW_INPUT = 0x0008;
        const uint ENABLE_MOUSE_INPUT = 0x0010;
        const uint ENABLE_INSERT_MODE = 0x0020;
        const uint ENABLE_QUICK_EDIT_MODE = 0x0040;
        const uint ENABLE_EXTENDED_FLAGS = 0x0080;
        const uint ENABLE_AUTO_POSITION = 0x0100;
        const uint ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200;

        const uint STD_INPUT_HANDLE = unchecked((uint)-10);
        public static void init() {
            uint conmode;
            IntPtr hInput = GetStdHandle(STD_INPUT_HANDLE);

            if (GetConsoleMode(hInput, out conmode)) {
                conmode &= ~ENABLE_QUICK_EDIT_MODE;
                conmode &= ~ENABLE_MOUSE_INPUT;

                if (!SetConsoleMode(hInput, conmode))
                    Console.WriteLine("SetConsoleMode failed with error {0}", Marshal.GetLastWin32Error());
            } else
                Console.WriteLine("GetConsoleMode failed with error {0}", Marshal.GetLastWin32Error());
        }
    }
}
