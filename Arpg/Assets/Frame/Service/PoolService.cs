using System;
using System.Collections.Generic;
using UnityEngine;

namespace Frame
{
    public class PoolService<T1>:Service where T1:class,new()
    {
        private Dictionary<Type, Queue<T1>> pools;
        public void Init()
        {
            pools = new Dictionary<Type, Queue<T1>>();
            Debug.Log("PoolService Init");
        }

        public T GetAsset<T>()where T:class, new()
        {
            T res=null;
            Queue<T1> outValue;
            if (pools.TryGetValue(typeof(T),out outValue)&&outValue.Count>0)
            {
                res = outValue.Dequeue() as T;
            }else if(outValue==null){
                pools.Add(typeof(T),new Queue<T1>());
            }
            if (res == null)
            {
                res = new T();
            }

            return res ;
        }
        

        public void Release<T>(T t)where T:class,new ()
        {
            Queue<T1> outValue;
            if (pools.TryGetValue(typeof(T), out outValue))
            {
                outValue.Enqueue(t as T1);
            }
        }

    }
}