using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame;

public class App : MonoBehaviour
{
   public static App AppInstance;

   void Awake()
   {
      AppInstance = this;
   }

   private List<Service> _services;

   public T GetService<T>()where T :class
   {
      foreach (var s in _services)
      {
         if (s is T)
         {
            return (T)s;
         }
      }

      return default(T);
   }

}
