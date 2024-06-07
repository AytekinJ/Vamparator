using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject fadeImage;
    public void startGame()
    {
        StartCoroutine(fade());
    }
    public void exitGame()
    {
        Application.Quit();
    }
    IEnumerator fade()
    {
        fadeImage.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

}
