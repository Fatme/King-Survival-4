namespace KingSurvival.Commands.PawnCommands
{
    using KingSurvival.Commands.Contracts;

    public class PawnDDownLeftCommand : MoveCommand, IMoveCommand
    {
        public PawnDDownLeftCommand()
            : base(3, 2)
        {
        }

        public override string Name
        {
            get { return "ddl"; }
        }
    }
}
