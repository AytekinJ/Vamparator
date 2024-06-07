using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject fadeImage;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;
    private void Update()
    {
        audioSource.volume = slider.value;
    }
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
