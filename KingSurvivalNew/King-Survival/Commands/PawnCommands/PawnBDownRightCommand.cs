namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnBDownRightCommand : MoveCommand, IMoveCommand
    {
        public PawnBDownRightCommand()
            : base(1, 1)
        {
        }

        public override string Name
        {
            get { return "bdr"; }
        }
    }
}
