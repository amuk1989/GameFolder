using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Main;
using UniRx;
using UnityEngine;

namespace Aim
{
    public class Weapon: MonoBehaviour
    {
        [SerializeField] private AimObject _aimObject;
        [SerializeField] private Gun _gun;
        [SerializeField] private InputController _inputController;
        [SerializeField] private float _rateOfFire;

        private Transform _aimTransform;
        private CancellationTokenSource _fireToken;

        private void Start()
        {
            _aimTransform = _aimObject.transform;

            _inputController
                .OnMainInputStatus()
                .Subscribe(input =>
                {
                    switch (input)
                    {
                        case InputStatus.OnHold:
                            _fireToken = new CancellationTokenSource();
                            FireTask(_fireToken.Token);
                            break;
                        case InputStatus.OnRelease:
                            StopFire();
                            break;
                        default:
                            break;
                    }

                })
                .AddTo(this);
        }

        private void Update()
        {
            var aimPosition = _aimTransform.position;
            var lookPosition = new Vector3(aimPosition.x, transform.position.y, aimPosition.z);
            transform.LookAt(lookPosition);
            _gun.LookAt(aimPosition);
        }

        private void OnDestroy()
        {
            StopFire();
        }

        private async Task FireTask(CancellationToken token)
        {
            do
            {
                _gun.Fire();
                await Task.Delay(TimeSpan.FromSeconds(60f / _rateOfFire), token);
            } while (!token.IsCancellationRequested);
        }

        private void StopFire()
        {
            if (_fireToken == null) return;
            _fireToken.Cancel();
            _fireToken.Dispose();
            _fireToken = null;
        }
    }
}