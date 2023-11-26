using TMPro;
using UnityEngine;

namespace Frame.Binding
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMP_TextBinding:BindingBase
    {
        private TMP_Text _text;
    }
}