using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] ScoreUI;
    Text ScoreText;
    
    void Update()
    {
        foreach (var score in ScoreUI)
        {
            ScoreText = score.GetComponent<Text>();
            ScoreText.text = $"Score : {GameManager.Instance.Score}";
        }
    }

}