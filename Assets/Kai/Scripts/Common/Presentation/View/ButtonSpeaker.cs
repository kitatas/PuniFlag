using Kai.Common.Application;
using Kai.Common.Presentation.Controller;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kai.Common.Presentation.View
{
    [RequireComponent(typeof(Button))]
    public sealed class ButtonSpeaker : MonoBehaviour
    {
        [SerializeField] private bool isSubscribe = default;
        [SerializeField] private ButtonType buttonType = default;

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

        private SeController _seController;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
        }

        private void Start()
        {
            if (isSubscribe)
            {
                button
                    .OnClickAsObservable()
                    .Subscribe(_ => Play())
                    .AddTo(this);
            }
        }

        public void Play()
        {
            _seController.PlaySe(buttonType);
        }
    }
}