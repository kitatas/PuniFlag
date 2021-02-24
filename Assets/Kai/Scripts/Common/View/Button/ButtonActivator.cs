using UnityEngine;

namespace Common.View.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class ButtonActivator : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;

        private void Awake()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
        }

        public void Activate(bool value)
        {
            _button.enabled = value;
        }
    }
}