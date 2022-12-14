using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadScene()
    {
        if (sceneIndex == 1)
        {
            PlayerPrefs.SetInt("vidaQt", 10);
            PlayerPrefs.SetInt("vidaMax", 10);
            PlayerPrefs.SetInt("PlayerDano", 1);
            PlayerPrefs.SetInt("SP1", 0);
            PlayerPrefs.SetInt("SP2", 0);
            PlayerPrefs.SetInt("SP3", 0);
        }
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerPrefs.Save();
        LoadScene();
    }
}