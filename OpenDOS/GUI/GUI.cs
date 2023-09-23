using Cosmos.Core.Memory;
using Cosmos.HAL.Drivers.Video;
using Cosmos.System.Graphics;
using PrismAPI.Filesystem.Filesystems.TAR;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenDOS.GUI
{
    public class GUI
    {
        public VBECanvas mainDesktopCanvas;

        public GUI()
        {
            mainDesktopCanvas = new VBECanvas();
            mainDesktopCanvas.Mode = new Mode();
        }

        public void Run()
        {
            while (true)
            {
                mainDesktopCanvas.Clear(Color.AliceBlue);
                Heap.Collect();
                mainDesktopCanvas.Display();
            }
        }
    }
}
