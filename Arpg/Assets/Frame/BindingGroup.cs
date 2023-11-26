using System.Collections.Generic;
using UnityEngine;

namespace Frame
{
    public class BindingGroup:MonoBehaviour
    {
        protected BaseC _baseC;
        public Dictionary<string, BindingBase> bindingDic;

        public void Init()
        {
            bindingDic = new Dictionary<string, BindingBase>();
            BindingBase[] bindingBases = GetComponents<BindingBase>();
            for (int i = 0; i < bindingBases.Length; i++)
            {
                string key=bindingBases[i].RealPath;
                if(!bindingDic.ContainsKey(key)&&!(bindingBases[i] is InheritBinding)){
                    bindingDic.Add(key,bindingBases[i]);
                }
            }
        }

        public void SendMessage(string name,MessageBase messageBase)
        {
            _baseC.HandleProxy(name,messageBase);
        }

        public void ReceiveMessage(string name,MessageBase messageBase)
        {
            bindingDic[name].ReceiveMessage(messageBase);
        }
    }
}