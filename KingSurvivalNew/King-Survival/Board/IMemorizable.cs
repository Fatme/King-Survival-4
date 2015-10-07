namespace KingSurvival.Board
{
    public interface IMemorizable
    {
        Memento SaveMemento();

        void RestoreMemento(Memento memento);
    }
}
