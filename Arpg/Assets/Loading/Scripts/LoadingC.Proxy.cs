using Frame;

namespace Loading
{
    public partial class LoadingC
    {
        public override ProxyBase HandleProxy(string name,ProxyBase proxyBase=null )
        {
            switch (name)
            {
                case nameof(Percent):
                    return percentFieldProxy;
            }

            return base.HandleProxy(name);
        }
    }
}