using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace Frame
{
    public class AddressableAssetService:AssetService
    {
        public T GetAsset<T>(string name)
        {
            T result = default(T);
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(name);
            handle.WaitForCompletion();
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                // 获取加载的资源
                result=handle.Result;
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
            
        }
    }
}