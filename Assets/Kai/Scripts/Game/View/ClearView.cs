using TMPro;
using UnityEngine;

namespace Game.View
{
    public sealed class ClearView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI clearText = default;

        public void Show()
        {
            clearText.enabled = true;
        }
    }
}