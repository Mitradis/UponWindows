using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UponWindows
{
    public partial class FormMain : Form
    {
        bool borderShow = false;
        int mouseWindowX = 0;
        int mouseWindowY = 0;

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;

        public FormMain()
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!borderShow)
            {
                mouseWindowX = e.X;
                mouseWindowY = e.Y;
                MouseMove += FormMain_MouseMove;
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (!borderShow)
            {
                MouseMove -= FormMain_MouseMove;
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (!borderShow)
            {
                Location = new Point(Cursor.Position.X - mouseWindowX, Cursor.Position.Y - mouseWindowY);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!borderShow)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                borderShow = true;
                button2.Visible = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                borderShow = false;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
