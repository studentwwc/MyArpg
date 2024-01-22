namespace Frame
{
    public class ProxyBase
    {
        
    }

    public class FieldProxy<T>:ProxyBase
    {
        public T value;
    }
}