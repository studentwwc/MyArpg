using System.Collections.Generic;
using UnityEngine;

namespace Frame
{
    public class BindingGroup:MonoBehaviour
    {
        public Dictionary<string, BindingBase> bindingDic;

        public void Init()
        {
            BindingBase[] bindingBases = GetComponents<BindingBase>();
            for (int i = 0; i < bindingBases.Length; i++)
            {
                string key=bindingBases[i].RealPath;
                if(!bindingDic.ContainsKey(key)&&!(bindingBases[i] is InheritBinding)){
                    bindingDic.Add(key,bindingBases[i]);
                }
            }
        }
    }
}