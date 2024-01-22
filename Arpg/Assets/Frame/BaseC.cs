using System;
using Unity.VisualScripting;
using UnityEngine;
using Util;

namespace Frame
{
    public partial class BaseC
    {
        protected string AssetName;
        
        protected GameObject Instance;
        protected BindingGroup _bindingGroup;
        protected bool isLoad;
        protected bool isUnLoad;
        protected bool isInstance;

        public Action LoadEvent;
        public Action UnLoadEvent;
        public Action CreateEvent;
        public Action DestroyEvent;
        
        public BaseC(BaseM baseM)
        {
            baseM._binding=_bindingGroup;
            Init();
        }

        #region Life
        
        protected virtual void Init()
        {
        }

        protected void Load()
        {
            LoadEvent?.Invoke();
            if (Instance == null)
            {
                Instance = App.AppInstance.GetService<AssetService>().GetAsset<GameObject>(AssetName);
                _bindingGroup = Instance.AutoComponent<BindingGroup>();
                _bindingGroup.Init(this);
                _bindingGroup.NotifyAll();
            }
        }

        protected void Create()
        {
            if (!isLoad)
            {
                Load();
                isLoad = true;
            }

            if (!isInstance)
            {
                isInstance = true;
                Instance = GameObject.Instantiate(Instance);
                Instance.name = AssetName;
            }
            CreateEvent?.Invoke();
        }

        public void Visible()
        {
            if (!isInstance)
            {
                Create();
            }
            Instance.GameObject().SetActive(true);
        }

        public void DisVisible()
        {
            if (!isInstance)
            {
                Create();
            }
            Instance.GameObject().SetActive(false);
        }

        protected void Destroy()
        {
            if (!isUnLoad)
            {
                UnLoad();
                isUnLoad = true;
            }
            DestroyEvent?.Invoke();
        }

        protected void UnLoad()
        {
            UnLoadEvent?.Invoke();
        }
        #endregion
    }
}