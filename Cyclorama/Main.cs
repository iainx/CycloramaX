using System;
using AppKit;

namespace Cyclorama
{
    static class MainClass
    {
        static void Main (string [] args)
        {
            NSApplication.Init ();
            NSApplication.Main (args);
        }
    }
}
