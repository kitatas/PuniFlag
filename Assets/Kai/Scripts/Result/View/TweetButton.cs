using Common.View.Button;
using Game.StepCount;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Result.View
{
    [RequireComponent(typeof(ButtonActivator))]
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class TweetButton : MonoBehaviour
    {
        private const string GAME_ID = "puni_flag";
        private const string HASH_TAG1 = "unityroom";
        private const string HASH_TAG2 = "unity1week";

        private StepCountModel _stepCountModel;
        private ButtonActivator _buttonActivator;
        private ButtonAnimator _buttonAnimator;

        [Inject]
        private void Construct(StepCountModel stepCountModel)
        {
            _stepCountModel = stepCountModel;
            _buttonActivator = GetComponent<ButtonActivator>();
            _buttonAnimator = GetComponent<ButtonAnimator>();
        }

        private void Start()
        {
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _buttonAnimator.Play();
                    var tweetText = $"{_stepCountModel.GetStepCount()}回でクリア！\n";
                    tweetText += $"#{HASH_TAG1} #{HASH_TAG2} #{GAME_ID}\n";
                    UnityRoomTweet.Tweet(GAME_ID, tweetText);
                })
                .AddTo(this);
        }
    }
}