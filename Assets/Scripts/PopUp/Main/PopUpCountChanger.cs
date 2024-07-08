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

        private GameManager.GameManager _gameManager;
        private TextMeshProUGUI _textMeshProUGUI;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public event Action<PopUpCountChanger> OnDisabled;

        [Inject]
        private void Inject(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
        }
    
        public void Enable()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            ChangeCount();
            StartTimer().AttachExternalCancellation(_cts.Token);
        }

        private void ChangeCount()
        {
            _textMeshProUGUI.text = $"+{_gameManager.UpgradesModel.GetClickPrice()}";
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
