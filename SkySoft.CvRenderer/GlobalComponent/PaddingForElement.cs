﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public static class PaddingForElement
    {
        public static int PadingBottomEltment(int arraySize, int index, int padingBottom)
        {
            return arraySize == index + 1 ? 0 : padingBottom;
        }
    }
}