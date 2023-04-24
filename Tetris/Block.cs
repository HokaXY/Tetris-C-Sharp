using System.Collections.Generic;
namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Titles { get; }

        protected abstract Position StartOffset { get; }

        public abstract int id { get; }
        public object Id { get; internal set; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }
        //lets try method which returns the grid positions occupied by the block factoring in the current rottation and offset

        public IEnumerable<Position> TitlePositions()
        {
            foreach (Position p in Titles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Titles.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0 )
            {
                rotationState = Titles.Length - 1;
            }
            else 
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
