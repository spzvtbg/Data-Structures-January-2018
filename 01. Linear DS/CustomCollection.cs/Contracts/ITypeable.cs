namespace CustomCollections.cs.Contracts
{
    public interface ITypeable
    {
        event TypeEventHandler ValueType;
    }

    public delegate int TypeEventHandler();
}
