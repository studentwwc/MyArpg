using System;
using UnityEngine;
namespace Frame
{
    public class BaseC:MonoBehaviour
    {
        protected string AssetName;

        protected GameObject Instance;
        protected BindingGroup _bindingGroup;
        protected bool isLoad;
        protected bool isUnLoad;

        public Action LoadEvent;
        public Action UnLoadEvent;
        

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
            LoadEvent?.Invoke();
        }

        protected void Create()
        {
            if (!isLoad)
            {
                Load();
                isLoad = true;
            }
        }

        protected void Visible()
        {
            
        }

        protected void DisVisible()
        {
            
        }

        protected void Destroy()
        {
            if (!isUnLoad)
            {
                UnLoad();
                isUnLoad = true;
            }
        }

        protected void UnLoad()
        {
            UnLoadEvent?.Invoke();
        }
        


        #endregion
        

        public virtual void HandleProxy(string name,MessageBase messageBase)
        {
            
        }
        
    }
}