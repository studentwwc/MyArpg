using TMPro;
using UnityEngine;

namespace Frame.Binding
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMP_TextBinding:BindingBase
    {
        private TMP_Text _text;

        public override void HandleProxy()
        {
            if (_text==null)
            {
                _text = GetComponent<TMP_Text>();
            }
            _text.text= (_BindingGroup.HandleProxy(realPath) as FieldProxy<string>)?.value;
            Debug.Log(_text.text);
        }
    }
}