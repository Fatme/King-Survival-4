namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnADownRightCommand : MoveCommand, IPlayerCommand
    {
        public PawnADownRightCommand()
            : base(0,1)
        {
        }

        public override string Name
        {
            get { return "adr"; }
        }

    }
}
