namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnADownRightCommand : MoveCommand, IMoveCommand
    {
        public PawnADownRightCommand()
            : base(0, 1)
        {
        }

        public override string Name
        {
            get { return "adr"; }
        }
    }
}
