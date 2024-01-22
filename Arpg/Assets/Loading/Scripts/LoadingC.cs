using Frame;

namespace Loading
{
    public partial class LoadingC:HierarchyC
    {
        public LoadingC():this(new LoadingM())
        {   
            base.Init();
            AssetName = "Loading";
            layer = 9;
        }

        public LoadingC(BaseM baseM) : base(baseM)
        {
            
        }
    }
}