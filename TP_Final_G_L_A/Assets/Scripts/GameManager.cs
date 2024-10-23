using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public static GameManager inst;

    [SerializeField] private GameObject scoreObject;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private PlayerMovement playerMovement;


    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMP_Text distanceText;

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
        pauseMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {

    }
}
