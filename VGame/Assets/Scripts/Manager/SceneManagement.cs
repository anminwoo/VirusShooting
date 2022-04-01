using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager;

    private void Awake()
    {
        if (sceneManager == null)
        {
            sceneManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (sceneManager != null)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void NextScene(String stageName)
    {
        SceneManager.LoadScene(stageName);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
}
