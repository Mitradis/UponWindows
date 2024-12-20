using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UponWindows
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        readonly IntPtr HWND_TOPMOST = new IntPtr(0);
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        int mouseWindowX = 0;
        int mouseWindowY = 0;
        int mousePosX;
        int mousePosY;
        int formWidth;
        int formHeight;

        public FormMain()
        {
            InitializeComponent();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseWindowX = e.X;
            mouseWindowY = e.Y;
            MouseMove += FormMain_MouseMove;
        }

        void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            MouseMove -= FormMain_MouseMove;
        }

        void FormMain_MouseLeave(object sender, EventArgs e)
        {
            MouseMove -= FormMain_MouseMove;
        }

        void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            Location = new Point(Cursor.Position.X - mouseWindowX, Cursor.Position.Y - mouseWindowY);
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePosX = MousePosition.X;
            mousePosY = MousePosition.Y;
            formWidth = Width;
            formHeight = Height;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove -= pictureBox1_MouseMove;
        }

        void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.MouseMove -= pictureBox1_MouseMove;
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Width = MousePosition.X - mousePosX + formWidth;
            Height = MousePosition.Y - mousePosY + formHeight;
        }

        void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
