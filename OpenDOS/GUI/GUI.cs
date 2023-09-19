using System;
using System.Collections.Generic;
using Cosmos.Core.Memory;
using Cosmos.HAL;
using Cosmos.System;
using IL2CPU.API.Attribs;
using PrismAPI.Graphics;
using PrismAPI.Hardware.GPU;

namespace OpenDOS.GUI
{
    public class GUI
    {
        [ManifestResourceStream(ResourceName = "OpenDOS.GUI.Resource.Mouse.bmp")]
        static byte[] mouse;
        public static Canvas mouseDisplay = Image.FromBitmap(mouse);

        public Display mainDisplayCanvas = null!;

        public int screen_Y = 600;
        public int screen_X = 800;

        public bool UpdateGUI = true;

        public void StartGUI()
        {
            MouseManager.ScreenWidth = (ushort)screen_X;
            MouseManager.ScreenHeight = (ushort)screen_Y;
            mainDisplayCanvas = Display.GetDisplay((ushort)screen_X, (ushort)screen_Y);

            while (UpdateGUI)
            {
                mainDisplayCanvas.Clear(Color.ClassicBlue);
                mainDisplayCanvas.DrawString(15, 15, $"{mainDisplayCanvas.GetFPS()} FPS", default, Color.White);
                mainDisplayCanvas.DrawImage((int)MouseManager.X, (int)MouseManager.Y, mouseDisplay);
                Heap.Collect();
                mainDisplayCanvas.Update();
            }
        }
    }
}
