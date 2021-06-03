using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class PolicyButtonView : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    var url = $"https://kitatas.github.io/PuniFlag/";
                    Application.OpenURL(url);
                })
                .AddTo(this);
        }
    }
}