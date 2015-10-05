namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;

    public class PawnBDownRightCommand : MoveCommand, IPlayerCommand
    {
        public PawnBDownRightCommand()
            : base(1,1)
        {
        }

        public override string Name
        {
            get { return "bdr"; }
        }

    }
}
