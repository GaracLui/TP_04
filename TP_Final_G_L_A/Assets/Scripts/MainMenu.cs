using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    public static MainMenu inst;

    [SerializeField] private TMP_Text scoreTextSpring;
    [SerializeField] private TMP_Text scoreTextSummer;
    [SerializeField] private TMP_Text scoreTextFall;
    [SerializeField] private TMP_Text scoreTextWinter;





    public bool unlockScene2 = false;
    [SerializeField] private int scoreMeta2 = 50;
    [SerializeField] private UnityEngine.UI.Button buttonSummer;

    public bool unlockScene3 = false;
    [SerializeField] private int scoreMeta3 = 70;
    [SerializeField] private UnityEngine.UI.Button buttonFall;

    public bool unlockScene4 = false;
    [SerializeField] private int scoreMeta4 = 100;
    [SerializeField] private UnityEngine.UI.Button buttonWinter;


    private void Awake()
    {
        inst = this;
    }


    private void Start()
    {
        // primavera score
        if (PlayerPrefs.HasKey("SpringMaxScore"))
        {
            if (scoreMeta2 <= PlayerPrefs.GetInt("SpringMaxScore"))
            {
                buttonSummer.interactable = true;
            }
            else
            {
                buttonSummer.interactable = false;
            }
        }
        else
        {
            //si no se inicio el maximo score
            PlayerPrefs.SetInt("SpringMaxScore", 0);
            buttonSummer.interactable = false;
        }

        scoreTextSpring.text = " MAX: " + PlayerPrefs.GetInt("SpringMaxScore");
        // fin primavera score

        // Verano score
        if (PlayerPrefs.HasKey("SummerMaxScore"))
        {
            if (scoreMeta3 <= PlayerPrefs.GetInt("SummerMaxScore"))
            {
                buttonFall.interactable = true;
            }
            else
            {
                buttonFall.interactable = false;
            }
        }
        else
        {
            //si no se inicio el maximo score
            PlayerPrefs.SetInt("SummerMaxScore", 0);
            buttonFall.interactable = false;
        }
        // informar al usuario
        if ((PlayerPrefs.GetInt("SummerMaxScore") <= 0) && (PlayerPrefs.GetInt("SpringMaxScore" ) >= scoreMeta2))
        {
            scoreTextSummer.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("SummerMaxScore") > 0)
            {
                scoreTextSummer.text = " MAX: " + PlayerPrefs.GetInt("SummerMaxScore");
            }
            else
            {
                scoreTextSummer.text = $" NECESITAS {scoreMeta2} PUNTOS";
            }
        }
        // fin Verano score


        // Otoño score
        if (PlayerPrefs.HasKey("FallMaxScore"))
        {
            if (scoreMeta4 <= PlayerPrefs.GetInt("FallMaxScore"))
            {
                buttonWinter.interactable = true;
            }
            else
            {
                buttonWinter.interactable = false;

            }
        }
        else
        {
            //si no se inicio el maximo score
            PlayerPrefs.SetInt("FallMaxScore", 0);
            buttonWinter.interactable = false;
        }
        // informar al usuario
        if ((PlayerPrefs.GetInt("FallMaxScore") <= 0) && (PlayerPrefs.GetInt("SummerMaxScore") >= scoreMeta3))
        {
            scoreTextFall.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("FallMaxScore") > 0)
            {
                scoreTextFall.text = " MAX: " + PlayerPrefs.GetInt("FallMaxScore");
            }
            else
            {
                scoreTextFall.text = $" NECESITAS {scoreMeta3} PUNTOS";
            }
        }
        // fin Otoño score


        // Invierno score
        if (!PlayerPrefs.HasKey("WinterMaxScore"))
        {

            //si no se inicio el maximo score
            PlayerPrefs.SetInt("WinterMaxScore", 0);
           
        }
        // informar al usuario
        if ((PlayerPrefs.GetInt("WinterMaxScore") <= 0) && (PlayerPrefs.GetInt("FallMaxScore") >= scoreMeta4))
        {
            scoreTextWinter.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("WinterMaxScore") > 0)
            {
                scoreTextWinter.text = " MAX: " + PlayerPrefs.GetInt("WinterMaxScore");
            }
            else
            {
                scoreTextWinter.text = $" NECESITAS {scoreMeta4} PUNTOS";
            }
        }
        // fin Invierno score

        //buttonSummer.interactable = unlockScene2 ? true : false;

        //buttonFall.interactable = unlockScene3 ? true : false;

        //buttonWinter.interactable = unlockScene4 ? true : false;
    }




    public void PlaySpring()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySummer()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayFall()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayWinter()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void RestartScores()
    {
        // primavera
        PlayerPrefs.SetInt("SpringMaxScore", 0);
        // Verano
        PlayerPrefs.SetInt("SummerMaxScore", 0);
        // Otoño
        PlayerPrefs.SetInt("FallMaxScore", 0);
        // Invierno score
        PlayerPrefs.SetInt("WinterMaxScore", 0);

        // reingresa al menu con las alteraciones
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
