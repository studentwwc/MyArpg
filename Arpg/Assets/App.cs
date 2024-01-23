using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Frame;
using Loading;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    public static App AppInstance;
    private LoadingC loadingC;
    [SerializeField] private GameObject canvas;
    private GameObject camera;

    #region Service

    private List<Service> _services;

    public T GetService<T>() where T : Service
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

    public void RegisterService<T>(T t) where T : Service
    {
        if (!_services.Contains(t))
        {
            _services.Add(t);
        }
    }

    public void UnRegisterService<T>(T t) where T : Service
    {
        if (_services.Contains(t))
        {
            _services.Remove(t);
        }
    }

    #endregion

    #region GameStart

    void Awake()
    {
        AppInstance = this;
    }

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    public void GameInit()
    {
        //Init Camera
        if (camera == null)
        {
            camera = new GameObject();
            camera.AddComponent<Camera>();
            camera.name = "Camera";
            camera.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        }

        //Service Init
        _services = new List<Service>();
        AssetService assetService = new AddressableAssetService();
        assetService.Init();
        RegisterService(assetService);
        PoolService<System.Object> poolService = new PoolService<System.Object>();
        poolService.Init();
        RegisterService(poolService);
    }

    public IEnumerator GameStart()
    {
        GameInit();
        loadingC = new LoadingC();
        loadingC.Visible();
        updates+=()=>
        {
            loadingC.Percent += 1;
        };
        yield return 0;
    }

    #endregion

    #region Update

    public Action updates;

    private void Update()
    {
        updates?.Invoke();
    }

    #endregion

    public void SwitchScene(string name)
    {
        
    }

    public void SetHierarchy(GameObject gameObject, int layer = 0)
    {
        if (layer < 0 || layer >= canvas.transform.childCount)
        {
            layer = 0;
        }

        Transform parent = canvas.transform.GetChild(layer);
        gameObject.transform.SetParent(parent);
    }
}