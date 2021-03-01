using Common.Sound.SE;
using UniRx;
using UnityEngine;
using Zenject;

namespace Common.View.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public sealed class ButtonSpeaker : MonoBehaviour
    {
        [SerializeField] private ButtonType buttonType = default;

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        private void Start()
        {
            GetComponent<UnityEngine.UI.Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _seController.PlaySe(buttonType))
                .AddTo(this);
        }
    }
}