using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCutScene : MonoBehaviour
{
    [SerializeField] private OldWomanBehavior _neenaBehavior;
    [SerializeField] private OldWomanBehavior _ruslanaBehavior;

    [SerializeField] private Radio _radio;
    [SerializeField] private SpriteRenderer _valve;

    private CancellationTokenSource _token = new();
    // Start is called before the first frame update
    private void Start()
    {
        Scenario();
    }

    private async void Scenario()
    {
        try
        {
            _valve.DOFade(0, 2f);
            await Task.Delay(TimeSpan.FromSeconds(2), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            _radio.SoundShow();
            await Task.Delay(TimeSpan.FromSeconds(48), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            _radio.SoundHide();
            await Task.Delay(TimeSpan.FromSeconds(4), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            _neenaBehavior.Show();
            await Task.Delay(TimeSpan.FromSeconds(9), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            _ruslanaBehavior.Show();
            await Task.Delay(TimeSpan.FromSeconds(18), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            _valve.DOFade(1, 2f);
            if (_token == null || _token.IsCancellationRequested) return;
            await Task.Delay(TimeSpan.FromSeconds(12), _token.Token);
            if (_token == null || _token.IsCancellationRequested) return;
            SceneManager.LoadScene("Game");
        }
        catch (Exception e)
        {

        }

    }

    private void OnDestroy()
    {
        _token?.Cancel();
        _token?.Dispose();
        _token = null;
    }
}
