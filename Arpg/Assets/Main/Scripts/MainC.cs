using Frame;

namespace Main
{
    public partial class MainC:HierarchyC
    {
        public MainC():this(new MainM())
        {
            AssetName = "MainC";
        }
        public MainC(MainM mainM) : base(mainM)
        {
            
        }
        
    }
}