namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownLeftCommand : PlayerCommand, IPlayerCommand
    {
        public PawnADownLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "adl"; }
        }

        public override int Direction
        {
            get { return 2; }
        }

        public override int FigureIndex
        {
            get { return 0; }
        }
    }
}
