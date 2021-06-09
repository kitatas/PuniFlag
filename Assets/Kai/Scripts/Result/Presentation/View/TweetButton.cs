using System;
using Kai.Common.Application;
using Kai.Common.Presentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Kai.Result.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class TweetButton : MonoBehaviour
    {
        private const string GAME_ID = "puni_flag";
        private const string HASH_TAG1 = "unityroom";
        private const string HASH_TAG2 = "unity1week";

        public void Init(LanguageType languageType, int stepCount)
        {
            var buttonAnimator = GetComponent<ButtonAnimator>();
            var message = $"{GetTweetMessage(languageType, stepCount)}\n";

            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    buttonAnimator.Play();
                    Tweet(message);
                })
                .AddTo(this);
        }

        private static string GetTweetMessage(LanguageType languageType, int stepCount)
        {
            switch (languageType)
            {
                case LanguageType.English:
                    return $"Clear in {stepCount} times!";
                case LanguageType.Japanese:
                    return $"{stepCount}回でクリア！";
                default:
                    throw new ArgumentOutOfRangeException(nameof(languageType), languageType, null);
            }
        }

        private static void Tweet(string message)
        {
#if UNITY_ANDROID

            var tweetText = message + $"#{GAME_ID}\n";
            tweetText += $"https://play.google.com/store/apps/details?id=com.KitaLab.PuniFlag";
            var url = $"https://twitter.com/intent/tweet?text={UnityWebRequest.EscapeURL(tweetText)}";
            Application.OpenURL(url);

#else

            var tweetText = message + $"#{HASH_TAG1} #{HASH_TAG2} #{GAME_ID}\n";
            UnityRoomTweet.Tweet(GAME_ID, tweetText);

#endif
        }
    }
}