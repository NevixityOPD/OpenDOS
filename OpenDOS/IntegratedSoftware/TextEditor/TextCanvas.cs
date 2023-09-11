using System;
using System.Collections.Generic;

namespace OpenDOS.IntegratedSoftware.TextEditor
{
    public class TextCanvas
    {
        public string fileName;
        public string filePath;

        public FileState fileState;

        public int cursorY = 0;
        public int cursorX = 0;

        public int startingLine = 0;
        public readonly int endLine = Console.WindowHeight - 2;

        public List<List<char>> textLine;

        public void Render()
        {
            
        }
    }
}
