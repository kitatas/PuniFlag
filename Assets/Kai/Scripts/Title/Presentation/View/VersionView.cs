using Kai.Common.Application;
using TMPro;
using UnityEngine;

namespace Kai.Title.Presentation.View
{
    public sealed class VersionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI version = default;

        private void Awake()
        {
            version.text = $"{VersionConfig.MAJOR_VERSION}.{VersionConfig.MINOR_VERSION}";
        }
    }
}