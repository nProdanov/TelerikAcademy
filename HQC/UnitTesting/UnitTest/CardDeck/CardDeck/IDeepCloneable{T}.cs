namespace CardDeck
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
