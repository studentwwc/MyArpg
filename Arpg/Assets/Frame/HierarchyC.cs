using System;
using UnityEngine;

namespace Frame
{
    public class HierarchyC:BaseC
    {
        protected int layer;
        protected RectTransform _rectTransform;

        protected override void Init()
        {
            CreateEvent += () =>
            {
                App.AppInstance.SetHierarchy(Instance,layer);
                RefreshPage();
            };
            
        }

        protected void RefreshPage()
        {
            _rectTransform=Instance.GetComponent<RectTransform>();
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = Vector2.one;

            // 设置偏移为零
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }

        public HierarchyC(BaseM baseM) : base(baseM)
        {
        }
    }
}