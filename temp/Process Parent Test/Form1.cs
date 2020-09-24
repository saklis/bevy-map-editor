using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Process_Parent_Test
{
    public partial class Form1 : Form
    {
        private const int SW_SHOWMAXIMIZED = 3;

        // Pinvoke declaration for ShowWindow
        private const int SW_SHOWNORMAL = 1;

        private IntPtr _processHandle;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private void Form1_Load(object sender, EventArgs e)
        {
            _processHandle = IntPtr.Zero;

            ProcessStartInfo info = new ProcessStartInfo("bevy_editor_viewport.exe");

            Process process = Process.Start(info);
            while (_processHandle == IntPtr.Zero)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    _processHandle = process.MainWindowHandle;
                }
                else
                {
                    Thread.Sleep(1000);
                    process.Refresh();
                    if (process.HasExited) break;
                }
            }

            if (_processHandle != IntPtr.Zero)
            {
                SetParent(_processHandle, panel3.Handle);
                //ShowWindow(_processHandle, SW_SHOWMAXIMIZED);
                MoveWindow(_processHandle, -10, -30, panel3.Width + 20, panel3.Height + 40, true);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            MoveWindow(_processHandle, -10, -30, panel3.Width + 20, panel3.Height + 40, true);
        }
    }
}