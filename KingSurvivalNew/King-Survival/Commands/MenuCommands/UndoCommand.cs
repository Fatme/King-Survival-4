namespace KingSurvival.Commands.CommonCommands
{
    using KingSurvival.Commands.Contracts;

    public class UndoCommand : Command, ICommand
    {
        public override string Name
        {
            get { return "undo"; }
        }

        public override void Execute(ICommandContext context)
        {
            if (context.Memory.Memento != null)
            {
                context.Board.RestoreMemento(context.Memory.Memento);
            }
        }
    }
}
