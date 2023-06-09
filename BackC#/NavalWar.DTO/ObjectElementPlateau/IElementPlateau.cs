﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DTO.ObjectElementPlateau
{
    public interface IElementPlateau
    {
        int X { get; set; }
        int Y { get; set; }
        string Type { get; set; }

        string ToString();

    }
}
