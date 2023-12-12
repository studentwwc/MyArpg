using UnityEngine;
namespace Frame
{
    public class BaseC:MonoBehaviour
    {
        protected string AssetName;

        protected GameObject Instance;
        protected BindingGroup _bindingGroup;

        public BaseC(string assetName)
        {
            AssetName = assetName;
        }
      
        #region Life
        
        protected void Init()
        {
            
        }

        protected void Load()
        {
        }

        protected void Create()
        {
            if (Instance == null)
            {
                Load();
            }
        }

        protected void Destroy()
        {
            if (Instance != null)
            {
                UnLoad();
            }
        }

        protected void UnLoad()
        {
            
        }
        


        #endregion
        

        public virtual void HandleProxy(string name,MessageBase messageBase)
        {
            
        }
        
    }
}