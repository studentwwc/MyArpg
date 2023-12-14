using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace Frame
{
    public class AddressableAssetService:AssetService
    {
        private Dictionary<string, System.Object> assetDic = new Dictionary<string, System.Object>();
        public T GetAsset<T>(string name)
        {
            if (assetDic.ContainsKey(name))
            {
                return (T)assetDic[name];
            }
            T result = default(T);
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(name);
            handle.WaitForCompletion();
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // 获取加载的资源
                result=handle.Result;
                assetDic.Add(name,result);
            }
            else
            {
                // 加载失败，处理错误
                Debug.LogError("Failed to load asset: " + handle.OperationException);
            }
            // 卸载资源
            Addressables.Release(handle);
            return result;
        }
        public void ReleaseAsset(string name)
        {
            if (assetDic.ContainsKey(name))
            {
                Addressables.Release(assetDic[name]);
                assetDic.Remove(name);
            }
        }
    }
}