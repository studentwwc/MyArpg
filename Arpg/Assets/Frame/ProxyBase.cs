namespace Frame
{
    public interface ProxyBase
    {
    }

    public class FieldProxy<T>:ProxyBase
    {
        public T value;
    }
}