using GM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
        GameManager.Score = 0;
    }
}
