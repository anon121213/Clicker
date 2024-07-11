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
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public event Action<PopUpCountChanger> OnDisabled;
    
        public void Enable()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            ChangeCount();
            StartTimer().AttachExternalCancellation(_cts.Token);
        }

        private void ChangeCount()
        {
            _textMeshProUGUI.text = $"+";
        }

        private async UniTask StartTimer()
        {
            await UniTask.WaitForSeconds(1.5f);
            OnDisabled?.Invoke(this);
        }

        private void OnDestroy()
        {
            _cts?.Dispose();
        }
    }
}
