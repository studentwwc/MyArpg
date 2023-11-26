using UnityEngine;
using UnityEngine.UI;

namespace Frame.Binding
{
    [RequireComponent(typeof(Text))]
    public class TextBinding:BindingBase
    {
        private Text _text;
    }
}