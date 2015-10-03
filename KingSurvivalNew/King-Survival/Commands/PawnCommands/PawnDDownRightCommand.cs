namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnDDownRightCommand : Command, IPlayerCommand
    {
        public PawnDDownRightCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "ddr"; }
        }

        public int Direction
        {
            get { return 1; }
        }

        public int FigureIndex
        {
            get { return 3; }
        }
    }
}
