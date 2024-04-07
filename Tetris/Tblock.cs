﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Tblock : Block
    {
        private readonly Position[][] tiles = new Position[][] // Wszystkie 4 pozycje rotacyjne bloku I
        {
            new Position[] {new(0, 1), new(1, 0), new(1, 1), new(1, 2) },
            new Position[] {new(0, 1), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] {new(1, 0), new(1, 1), new(1, 2), new(2, 1) },
            new Position[] {new(0, 1), new(1, 0), new(1, 1), new(2, 1) }
        };

        public override int Id => 6;
        protected override Position StartOffset => new Position(0, 3); //Pozycja startowa dla bloku
        protected override Position[][] Tiles => tiles;
    }
}
