
namespace Tetris
{
    public class GameGrid
    {
        //this class holds to dimensional rectangular array

        private readonly int[,] grid;
        
        public int Rows { get; }

        public int Columns { get; }

        public int this [int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }
        //if a given row is inside the grid or not
        public bool IsInside( int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }
        //if the given cell is empty or not
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }
        //if the entire row is full
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r,c] == 0)
                {
                    return false;
                }
            }
            return true;
        }
        //if the entire row is empty
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        //to clear the row
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        //to move down the row 
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        public int ClearFullRows()
        {
            int cleared = 0;

            for(int r = Rows-1; r >= 0; r--)
            {
                if(IsRowFull(r))
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
