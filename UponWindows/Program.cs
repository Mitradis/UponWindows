using System;
using System.Windows.Forms;

namespace UponWindows
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
