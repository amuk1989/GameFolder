using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    
    private void Start()
    {
        Cursor.visible = true;
        
        _startButton
            .OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene("StartCutScene"))
            .AddTo(this);

        _exitButton
            .OnClickAsObservable()
            .Subscribe(_ => Application.Quit())
            .AddTo(this);
    }
}
