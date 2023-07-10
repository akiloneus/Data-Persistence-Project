//using System;
//using System.IO;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{


    [SerializeField] private GameObject highScoreText;    

    private void Start()
    {
        Load();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Load()
    {
        UserInfo.Instance.LoadHighScore();

        highScoreText.GetComponent<TMP_Text>().text = $"High Score: {UserInfo.Instance.bestScore} - {UserInfo.Instance.recordPlayerName}";
    }
}
