﻿using System;
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
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private AimObject _aimObject;
        [SerializeField] private Gun _gun;
        [SerializeField] private InputController _inputController;
        [SerializeField] private float _rateOfFire;
        [SerializeField] private AudioSource _shootSound;

        private Transform _aimTransform;
        private CancellationTokenSource _fireToken;

        private void Start()
        {
            _aimTransform = _mainCamera.transform;

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
            RaycastHit hit;
            var isCast = Physics.Raycast(_aimTransform.position, _aimTransform.forward, out hit, 100);
            var aimPosition = isCast? hit.point: _aimTransform.position + _aimTransform.forward * 100;
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
            _shootSound.Play();
            do
            {

                _gun.Fire();
                await Task.Delay(TimeSpan.FromSeconds(_rateOfFire/60f), token);
            } while (!token.IsCancellationRequested);
            StopFire();
        }

        private void StopFire()
        {
            if (_fireToken == null) return;
            _shootSound.Stop();
            _fireToken.Cancel();
            _fireToken.Dispose();
            _fireToken = null;
            Debug.Log("StopFire");
        }
    }
}