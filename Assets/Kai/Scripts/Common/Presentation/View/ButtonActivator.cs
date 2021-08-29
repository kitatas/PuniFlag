using UnityEngine;
using UnityEngine.UI;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonActivator : MonoBehaviour
    {
        private Button _button;
        public Button button => _button ??= GetComponent<Button>();

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