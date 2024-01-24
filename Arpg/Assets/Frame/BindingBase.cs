using UnityEngine;

namespace Frame
{
    public class BindingBase:MonoBehaviour
    {
        
        [SerializeField]
        private string path;

        [HideInInspector] public BindingGroup _BindingGroup;

        protected string realPath;
        public string RealPath
        {
            get
            {
                if (string.IsNullOrEmpty(realPath))
                {
                    InheritBinding inheritBinding= GetComponentInParent<InheritBinding>();
                    if (inheritBinding == null)
                    {
                        realPath = path;
                    }
                    else
                    {
                        realPath = inheritBinding.path+"."+transform.GetSiblingIndex()+"."+path;
                    }
                }

                return realPath;
            }
        }

        public void Notify()
        {
            HandleProxy();
        }

        public virtual void HandleProxy()
        {
            _BindingGroup.HandleProxy(realPath);
        }
    }
}