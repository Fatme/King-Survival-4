namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownLeftCommand : MoveCommand, IPlayerCommand
    {
        public PawnADownLeftCommand()
            : base(0,2)
        {
        }

        public override string Name
        {
            get { return "adl"; }
        }

    }
}
