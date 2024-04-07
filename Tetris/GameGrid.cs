using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        /*
         Klasa reprezentuje siatke pola gry z zapisanymi danymi dotyczącymi bloków niekontrolowanych przez gracza
         */
        private readonly int[,] grid;

        public int Rows { get; } //Szeregi
        public int Columns { get; } //Kolumny

        public int this[int r, int c] // prosty indekser ułatwiający dostęp do siatki
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        // Konstruktor umożliwia tworzenie niestandardowych siatek
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[Rows, Columns];
        }

        public bool IsInside(int r, int c) //metoda sprawdzająca czy blok o danych koordynatach należy do siatki
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c) //metoda sprawdzająca czy dany blok jest pusty (oraz czy należy do planszy)
        {
            return IsInside(r, c) && grid[r, c] == 0;        
        }

        public bool IsRowFull(int r) //metoda sprawdzająca czy cały szereg jest pełny
        {
            for(int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int r) //metoda sprawdzająca czy cały szereg jest pusty
        {
            for(int c = 0; c< Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int r) //metoda wyzerowująca dany szereg
        {
            for (int c = 0; r < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows) //Metoda opuszczająca szeregi w dół od r o numRows szeregów
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows() // metoda czyszcząca pełne wiersze
        {
            int cleared = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
