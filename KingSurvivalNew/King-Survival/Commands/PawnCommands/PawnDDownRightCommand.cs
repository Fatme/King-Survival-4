namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnDDownRightCommand : MoveCommand, IMoveCommand
    {
        public PawnDDownRightCommand()
            : base(3, 1)
        {
        }

        public override string Name
        {
            get { return "ddr"; }
        }
    }
}
