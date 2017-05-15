using System;
using System.Windows.Forms;

namespace PathClip
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string newText = PathUtil.CreateString(args);
            Clipboard.SetText(newText);
        }
    }
}
