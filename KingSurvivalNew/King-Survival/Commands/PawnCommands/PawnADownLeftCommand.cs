namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnADownLeftCommand : MoveCommand, IMoveCommand
    {
        public PawnADownLeftCommand()
            : base(0, 2)
        {
        }

        public override string Name
        {
            get { return "adl"; }
        }
    }
}
