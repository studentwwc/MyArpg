using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Frame.Binding
{
    public class ScrollViewBinding : BindingBase
    {
        public RectTransform template;
        public RectTransform content;
        private List<RectTransform> itemList;

        public void Init()
        {
            Assert.IsTrue(template != null);
            template.gameObject.SetActive(false);
        }

        public override void HandleProxy()
        {
            FieldProxy<int> fieldProxy = _BindingGroup.HandleProxy(realPath) as FieldProxy<int>;
            if (fieldProxy != null)
            {
                int count = fieldProxy.value;

                for (int i = 0; i < count; i++)
                {
                    RectTransform item = Instantiate(template, content, true);
                    itemList.Add(item);
                }
            }
            else
            {
                Debug.LogError("Failed to get FieldProxy<int> from HandleProxy");
            }
        }
    }
}