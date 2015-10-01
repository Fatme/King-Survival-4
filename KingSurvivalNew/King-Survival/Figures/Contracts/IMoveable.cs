namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Commands;

    //TODO:Maybe later do it the figure IMoveable not the player
    interface IMoveable
    {
        Move Move(string command);
    }
}
