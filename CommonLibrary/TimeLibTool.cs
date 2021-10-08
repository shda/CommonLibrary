using System;
using System.Threading;
using UniRx.Async;
using UnityEngine;

namespace CommonSouzM.SouzMCore.Common.Lib
{
    public class TimeLibTool
    {
        public static async UniTask ChangeValueToDuration(float from, float to, float duration,
            Action<float> onValue = null,
            CancellationTokenSource cancellationToken = null,
            Action onComplete = null)
        {
            float inter = 0;

            while (inter < 1)
            {
                inter += Time.deltaTime / duration;
                var value = Mathf.Lerp(from , to , inter);
                onValue?.Invoke(value);
                await UniTask.Yield();
                
                if(cancellationToken != null && cancellationToken.IsCancellationRequested)
                    return;
            }
            
            onValue?.Invoke(to);
            onComplete?.Invoke();
        }
    }
}