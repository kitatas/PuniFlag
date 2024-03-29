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
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    var url = $"https://kitatas.github.io/PuniFlag/{detailPath}/";
                    Application.OpenURL(url);
                })
                .AddTo(this);
        }
    }
}