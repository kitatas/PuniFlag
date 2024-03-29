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
                    return $"Clear in {stepCount.ToString()} times!";
                case LanguageType.Japanese:
                    return $"{stepCount.ToString()}回でクリア！";
                default:
                    throw new ArgumentOutOfRangeException(nameof(languageType), languageType, null);
            }
        }

        private static void Tweet(string message)
        {
#if UNITY_ANDROID

            var tweetText = message + $"#{GameConfig.GAME_ID}\n";
            tweetText += $"https://play.google.com/store/apps/details?id=com.KitaLab.PuniFlag";
            var url = $"https://twitter.com/intent/tweet?text={UnityWebRequest.EscapeURL(tweetText)}";
            Application.OpenURL(url);

#else

            var tweetText = message + $"#{GameConfig.HASH_TAG1} #{GameConfig.HASH_TAG2} #{GameConfig.GAME_ID}\n";
            UnityRoomTweet.Tweet(GameConfig.GAME_ID, tweetText);

#endif
        }
    }
}