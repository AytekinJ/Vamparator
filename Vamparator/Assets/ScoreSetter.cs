using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using GM;

public class ScoreSetter : MonoBehaviour
{
    Text ScoreText;

    void Start()
    {
        ScoreText = GetComponent<Text>();
        ScoreText.text = GameManager.Score.ToString();
    }

    void Update()
    {
        ScoreText.text = GameManager.Score.ToString();
    }
}
