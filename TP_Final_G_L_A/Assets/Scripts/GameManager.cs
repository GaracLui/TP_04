using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public static GameManager inst;

    //[SerializeField] private MainMenu menu;

    [SerializeField] private GameObject scoreObject;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private PlayerMovement playerMovement;


    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private TMP_Text pauseDistanceText;
    [SerializeField] private TMP_Text pauseScoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "COMIDA: " + score;
        // Increase the player's speed
        playerMovement.IncreaseSpeed();
    }

    private void Awake()
    {
        inst = this;
    }

    public void Pause()
    {
        //Time.timeScale = 1;
        scoreObject.SetActive(false);
        pauseMenu.SetActive(true);

        pauseScoreText.text = "COMIDA: " + score;
        pauseDistanceText.text = "DISTANCIA: " + (int)playerObject.transform.position.z;

        //Time.timeScale = 0;
        //MainMenu.inst.UnlockNextLevel(score, SceneManager.GetActiveScene().buildIndex);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
