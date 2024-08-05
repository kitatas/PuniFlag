using Kai.Common.Application;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ExternalSiteButtonView : MonoBehaviour
    {
        [SerializeField] private string detailPath = default;

        private void Start()
        {
            var url = $"https://kitatas.github.io/games/{GameConfig.GAME_ID}/{detailPath}/";
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => Application.OpenURL(url))
                .AddTo(this);
        }
    }
}