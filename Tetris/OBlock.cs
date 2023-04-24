namespace Tetris
{
    public class OBlock : Block
    {
        private readonly Position[][] titles = new Position[][]
        {
            new Position[] { new(0,0), new(0,1), new(1,0), new(1,1) }
        };

        public override int id => 4;

        protected override Position StartOffset => new Position(0, 4);

        protected override Position[][] Titles => titles;
    }
}
