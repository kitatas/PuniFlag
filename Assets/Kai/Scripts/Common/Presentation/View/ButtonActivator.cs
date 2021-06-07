using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonActivator : MonoBehaviour
    {
        private Button _button;

        public Button button
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<Button>();
                }

                return _button;
            }
        }

        public void Activate(bool value)
        {
            button.enabled = value;
        }

        public void SetInteractable(bool value)
        {
            button.interactable = value;
        }
    }
}