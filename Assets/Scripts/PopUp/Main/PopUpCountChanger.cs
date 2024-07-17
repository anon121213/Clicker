using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using VContainer;

namespace PopUp.Main
{
    public class PopUpCountChanger: MonoBehaviour
    {
        [SerializeField] private float _timer = 1.5f;
        
        private TextMeshProUGUI _textMeshProUGUI;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public event Action<PopUpCountChanger> OnDisabled;
    
        public void Enable(int PopUpCount)
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            ChangeCount(PopUpCount);
            StartTimer().AttachExternalCancellation(_cts.Token);
        }

        private void ChangeCount(int count) =>
            _textMeshProUGUI.text = $"+{count}";

        private async UniTask StartTimer()
        {
            await UniTask.WaitForSeconds(1.5f);
            OnDisabled?.Invoke(this);
        }

        private void OnDestroy() =>
            _cts?.Dispose();
    }
}
