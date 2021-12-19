using System;
using Kai.Common.Application;
using Kai.Common.Presentation.View;
using Kai.Title.Domain.UseCase.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Kai.Title.Presentation.View
{
    [RequireComponent(typeof(ButtonAnimator))]
    public sealed class TweetButtonView : MonoBehaviour
    {
        public void Init(ISaveLanguageUseCase languageUseCase, int clearCount)
        {
            var buttonAnimator = GetComponent<ButtonAnimator>();
            buttonAnimator.button
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    buttonAnimator.Play();
                    var message = GetTweetMessage(languageUseCase.language, clearCount);
                    Tweet(message);
                })
                .AddTo(this);
        }

        private static string GetTweetMessage(LanguageType languageType, int clearCount)
        {
            switch (languageType)
            {
                case LanguageType.English:
                {
                    return clearCount switch
                    {
                        0 => $"I haven't cleared even one...", // 未クリア
                        1 => $"Cleared 1 stage!", // 1つクリア
                        GameConfig.FREE_PLAY_COUNT => $"Cleared all stages!", // 全クリア
                        _ => $"Cleared {clearCount.ToString()} stages!"
                    };
                }
                case LanguageType.Japanese:
                {
                    return clearCount switch
                    {
                        0 => $"1つもクリアできていない...", // 未クリア
                        GameConfig.FREE_PLAY_COUNT => $"全てのステージをクリアした！", // 全クリア
                        _ => $"{clearCount.ToString()}個のステージをクリアした！"
                    };
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(languageType), languageType, null);
            }
        }

        private static void Tweet(string message)
        {
#if UNITY_ANDROID

            var tweetText = $"{message}\n" + $"#{GameConfig.GAME_ID}\n";
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