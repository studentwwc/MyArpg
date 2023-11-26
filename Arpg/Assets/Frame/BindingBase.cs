using UnityEngine;

namespace Frame
{
    public class BindingBase:MonoBehaviour
    {
        [SerializeField]
        private string path;

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
                        realPath = inheritBinding.path;
                    }
                }

                return realPath;
            }
        }

        protected virtual void SendMessage()
        {
            
        }

        public virtual void ReceiveMessage(MessageBase messageBase)
        {
            
        }
    }
}