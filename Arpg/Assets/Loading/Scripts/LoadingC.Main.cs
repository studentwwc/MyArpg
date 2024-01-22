using Frame;

namespace Loading
{
    public partial class LoadingC
    {
        private int percent;
        private FieldProxy<string> percentFieldProxy;
        public int Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;
                if (percentFieldProxy == null)
                {
                    percentFieldProxy = new FieldProxy<string>();
                }
                percentFieldProxy.value = percent.ToString();
                _bindingGroup.Notity(nameof(Percent));
            }
        }
        private string tips;
    }
}