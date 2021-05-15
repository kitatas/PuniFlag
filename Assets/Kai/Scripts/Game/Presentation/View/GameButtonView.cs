using System;
using Kai.Common.Presentation.View;
using UniRx;
using UnityEngine;

namespace Kai.Game.Presentation.View
{
    [RequireComponent(typeof(ButtonActivator))]
    [RequireComponent(typeof(ButtonAnimator))]
    [RequireComponent(typeof(ButtonSpeaker))]
    public sealed class GameButtonView : MonoBehaviour
    {
        private readonly Subject<Unit> _subject = new Subject<Unit>();

        private ButtonAnimator _buttonAnimator;
        private ButtonSpeaker _buttonSpeaker;

        private void Awake()
        {
            _buttonAnimator = GetComponent<ButtonAnimator>();
            _buttonSpeaker = GetComponent<ButtonSpeaker>();
        }

        private void Start()
        {
            _buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ => _subject.OnNext(Unit.Default))
                .AddTo(this);
        }

        public IObservable<Unit> OnPush() => _subject;

        public void Push()
        {
            _buttonAnimator.Play();
            _buttonSpeaker.Play();
        }
    }
}