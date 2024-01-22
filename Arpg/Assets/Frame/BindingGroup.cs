using System.Collections.Generic;
using UnityEngine;

namespace Frame
{
    public class BindingGroup:MonoBehaviour
    {
        public BaseC _baseC;
        private Dictionary<string, BindingBase> bindingDic;

        public void Init(BaseC baseC)
        {
            _baseC = baseC;
            bindingDic = new Dictionary<string, BindingBase>();
            BindingBase[] bindingBases = GetComponentsInChildren<BindingBase>();
            for (int i = 0; i < bindingBases.Length; i++)
            {
                string key=bindingBases[i].RealPath;
                if(!bindingDic.ContainsKey(key)&&!(bindingBases[i] is InheritBinding)){
                    bindingDic.Add(key,bindingBases[i]);
                    bindingBases[i]._BindingGroup = this;
                }
            }
            NotifyAll();
        }

        public void NotifyAll()
        {
            foreach (var temp in bindingDic)
            {
                temp.Value.Notify();
            }
        }

        public void Notity(string name)
        {
            if (bindingDic.ContainsKey(name))
            {
                bindingDic[name].Notify();
            }
        }

        public ProxyBase HandleProxy(string name,ProxyBase proxyBase=null)
        { 
            return _baseC.HandleProxy(name);
        }
        
    }
}