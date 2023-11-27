using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private string _nextSceneName;
    private void Start()
    {
        Cursor.visible = true;
        
        _startButton
            .OnClickAsObservable()
            .Subscribe(_ => SceneManager.LoadScene(_nextSceneName))
            .AddTo(this);
    }
}
