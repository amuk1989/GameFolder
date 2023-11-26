using System;
using UniRx;
using UnityEngine;

namespace Main
{
    public class InputController: MonoBehaviour
    {
        private IDisposable _inputFlow;
        private readonly ReactiveProperty<InputStatus> _onMainInputStatus = new(InputStatus.OnRelease);

        public IObservable<InputStatus> OnMainInputStatus() => _onMainInputStatus.AsObservable();

        private void Start()
        {
            StartInput();
        }

        public void StartInput()
        {
            _inputFlow = Observable
                .EveryUpdate()
                .Subscribe(_ =>
                {
                    if (Input.GetMouseButtonDown(0)) _onMainInputStatus.Value = InputStatus.OnHold;
                    if (Input.GetMouseButtonUp(0)) _onMainInputStatus.Value = InputStatus.OnRelease;
                });
        }

        public void StopInput()
        {
            _inputFlow?.Dispose();
        }

        private void OnDestroy()
        {
            _inputFlow?.Dispose();
        }
    }

    public enum InputStatus
    {
        OnHold,
        OnRelease
    }
}