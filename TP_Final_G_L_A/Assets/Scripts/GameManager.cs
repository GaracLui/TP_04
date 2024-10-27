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

        scoreObject.SetActive(false);
        pauseMenu.SetActive(true);

        pauseScoreText.text = "COMIDA: " + score;
        pauseDistanceText.text = "DISTANCIA: " + (int)playerObject.transform.position.z;

        // actuliza datos segun el nivel
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                // primavera score
                if (PlayerPrefs.HasKey("SpringMaxScore"))
                {
                    if (score > PlayerPrefs.GetInt("SpringMaxScore"))
                    {
                        PlayerPrefs.SetInt("SpringMaxScore", score);
                    }
                }
                else
                {
                    //si no se inicio el maximo score
                    PlayerPrefs.SetInt("SpringMaxScore", score);
                }
                // fin primavera score
                break;
            case 2:
                // Verano score
                if (PlayerPrefs.HasKey("SummerMaxScore"))
                {
                    if (score > PlayerPrefs.GetInt("SummerMaxScore"))
                    {
                        PlayerPrefs.SetInt("SummerMaxScore", score);
                    }
                }
                else
                {
                    //si no se inicio el maximo score
                    PlayerPrefs.SetInt("SummerMaxScore", score);
                }
                // fin Verano score
                break;
            case 3:
                // Otoño score
                if (PlayerPrefs.HasKey("FallMaxScore"))
                {
                    if (score > PlayerPrefs.GetInt("FallMaxScore"))
                    {
                        PlayerPrefs.SetInt("FallMaxScore", score);
                    }
                }
                else
                {
                    //si no se inicio el maximo score
                    PlayerPrefs.SetInt("FallMaxScore", score);
                }
                // fin Otoño score
                break;
            case 4:
                // Invierno score
                if (PlayerPrefs.HasKey("WinterMaxScore"))
                {
                    if (score > PlayerPrefs.GetInt("WinterMaxScore"))
                    {
                        PlayerPrefs.SetInt("WinterMaxScore", score);
                    }
                }
                else
                {
                    //si no se inicio el maximo score
                    PlayerPrefs.SetInt("WinterMaxScore", score);
                }
                // fin Invierno score
                break;
            default:
                break;

        }
    }

    public void Restart()
    {
        score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
