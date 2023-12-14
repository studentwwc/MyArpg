using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frame
{
    public interface AssetService : Service
    {
        public T GetAsset<T>(string name);

        public void ReleaseAsset(string name);
    }
}

