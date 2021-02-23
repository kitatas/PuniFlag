using System;
using Common.Sound.SE;
using Common.View.Button;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Stage
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class RotateButton : MonoBehaviour
    {
        [SerializeField] private RotateDirection rotateDirection = default;
        private readonly Subject<Unit> _subject = new Subject<Unit>();
        public IObservable<Unit> onPush => _subject;

        private SeController _seController;
        private StageRotator _stageRotator;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(SeController seController)
        {
            _seController = seController;
            _stageRotator = FindObjectOfType<StageRotator>();
            _buttonAnimator = GetComponent<ButtonAnimator>();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => _subject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public void Push()
        {
            _seController.PlaySe(SeType.Decision);
            _stageRotator.Rotate(rotateDirection);
            _buttonAnimator.Play();
        }
    }
}