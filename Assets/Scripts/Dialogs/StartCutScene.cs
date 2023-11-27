using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
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
    // Start is called before the first frame update
    private void Start()
    {
        Scenario();
    }

    private async void Scenario()
    {
        _valve.DOFade(0, 2f);
        await Task.Delay(TimeSpan.FromSeconds(2));
        _radio.SoundShow();
        await Task.Delay(TimeSpan.FromSeconds(48));
        _radio.SoundHide();
        await Task.Delay(TimeSpan.FromSeconds(4));
        _neenaBehavior.Show();
        await Task.Delay(TimeSpan.FromSeconds(9));
        _ruslanaBehavior.Show();
        await Task.Delay(TimeSpan.FromSeconds(18));
        _valve.DOFade(1, 2f);
        await Task.Delay(TimeSpan.FromSeconds(15));
        SceneManager.LoadScene("Game");
    }
}
