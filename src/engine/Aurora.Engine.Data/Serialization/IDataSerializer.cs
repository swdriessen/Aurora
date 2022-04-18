namespace Aurora.Engine.Data.Serialization
{
    public interface IDataSerializer<T> where T : class
    {
        T? Deserialize(string json);

        string Serialize(T element);
    }
}