using Kai.Common.Data.Entity;
using Kai.Common.Extension;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View.Screen
{
    public sealed class ConfigScreenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title = default;
        [SerializeField] private TextMeshProUGUI language = default;
        [SerializeField] private TextMeshProUGUI volume = default;

        public void Show(ConfigScreen configScreen)
        {
            title.SetTextData(configScreen.title);
            language.SetTextData(configScreen.language);
            volume.SetTextData(configScreen.volume);
        }
    }
}