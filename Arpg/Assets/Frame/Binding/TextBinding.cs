using UnityEngine;
using UnityEngine.UI;

namespace Frame.Binding
{
    [RequireComponent(typeof(Text))]
    public class TextBinding:BindingBase
    {
        private Text _text;
        public string test;
        
        public override void HandleProxy()
        {
            if (_text==null)
            {
                _text = GetComponent<Text>();
            }
            
            test = (_BindingGroup.HandleProxy(realPath) as FieldProxy<string>)?.value;
            _text.text = test;
            // 强制触发 UI 布局的重建
            LayoutRebuilder.ForceRebuildLayoutImmediate(_text.rectTransform);
            // 输出日志
            Debug.Log("wwc------>" + _text.text);
            Debug.Log("wwc------>" + test);
        }
    }
}