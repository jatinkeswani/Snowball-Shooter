using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playButton, nextButton, retryButton;
    public GameObject snowSoundPrefab;
    public AudioSource cheerAudio, noAudio;
    public GameObject noEmoji, cheerEmoji;

    private void Awake()
    {
        instance = this;
    }

    public void ShowRetryButton()
    {
        retryButton.SetActive(true);
        noEmoji.SetActive(true);
        noAudio.Play();
    }

    public void ShowNextButton()
    {
        nextButton.SetActive(true);
        cheerEmoji.SetActive(true);
        cheerAudio.Play();
    }

    public void PlayButton()
    {
        PlayerManager.instance.gameStarted = true;
        playButton.SetActive(false);
    }

    public void RetryButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
