using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Kai.Common.Extension
{
    public static class MonoBehaviourExtension
    {
        public static void DelayAction(this MonoBehaviour monoBehaviour, float delayTime, Action action)
        {
            var token = monoBehaviour.GetCancellationTokenOnDestroy();
            DelayActionAsync(delayTime, action, token).Forget();
        }

        public static async UniTask DelayActionAsync(float delayTime, Action action, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(delayTime), cancellationToken: token);

            action?.Invoke();
        }
    }
}