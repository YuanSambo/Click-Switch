using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public static GameManager Instance;
    public  int Score = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Restart();
            }
        }
    }

    private void Start()
    {
        SoundManager.Instance.Play("Background");
        Score = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Battle");
    }

    public void GameOver()
    {
        isGameOver = true;
    }
    public void Clear()
    {
        var Enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }

    }
    public void Point()
    {
        Score++;
    }

  
}
