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


    private string keySpring = "SpringMaxScore";
    private string keySummer = "SummerMaxScore";
    private string keyFall = "FallMaxScore";
    private string keyWinter = "WinterMaxScore";

    public bool unlockSceneSummer = false;
    [SerializeField] private int scoreMetaSummer = 50;
    [SerializeField] private UnityEngine.UI.Button buttonSummer;

    public bool unlockSceneFall = false;
    [SerializeField] private int scoreMetaFall = 70;
    [SerializeField] private UnityEngine.UI.Button buttonFall;

    public bool unlockSceneWinter = false;
    [SerializeField] private int scoreMetaWinter = 100;
    [SerializeField] private UnityEngine.UI.Button buttonWinter;


    private void Awake()
    {
        inst = this;
    }


    private void Start()
    {
        // primer nivel ingresa "" o " " como previo nivel
        CheckKeyScoreAndUnlockLevel(keySpring, scoreMetaSummer, buttonSummer);
        UpdateScoreText(keySpring, "", 0, scoreTextSpring);

        CheckKeyScoreAndUnlockLevel(keySummer, scoreMetaFall, buttonFall);
        UpdateScoreText(keySummer, keySpring, scoreMetaSummer, scoreTextSummer);

        CheckKeyScoreAndUnlockLevel(keyFall, scoreMetaWinter, buttonWinter);
        UpdateScoreText(keyFall, keySummer, scoreMetaFall, scoreTextFall);

        // ultimo nivel ingresa 0 como la meta del siguiente nivel
        CheckKeyScoreAndUnlockLevel(keyWinter, 0, buttonWinter);
        UpdateScoreText(keyWinter, keyFall, scoreMetaWinter, scoreTextWinter);

        /*
        // primavera score
        if (PlayerPrefs.HasKey("SpringMaxScore"))
        {
            if (scoreMetaSummer <= PlayerPrefs.GetInt("SpringMaxScore"))
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

        scoreTextSpring.text = " PUNTOS: " + PlayerPrefs.GetInt("SpringMaxScore");
        // fin primavera score

        // Verano score
        if (PlayerPrefs.HasKey("SummerMaxScore"))
        {
            if (scoreMetaFall <= PlayerPrefs.GetInt("SummerMaxScore"))
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
        if ((PlayerPrefs.GetInt("SummerMaxScore") <= 0) && (PlayerPrefs.GetInt("SpringMaxScore" ) >= scoreMetaSummer))
        {
            scoreTextSummer.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("SummerMaxScore") > 0)
            {
                scoreTextSummer.text = " PUNTOS: " + PlayerPrefs.GetInt("SummerMaxScore");
            }
            else
            {
                scoreTextSummer.text = $" NECESITAS {scoreMetaSummer} PUNTOS";
            }
        }
        // fin Verano score


        // Otoño score
        if (PlayerPrefs.HasKey("FallMaxScore"))
        {
            if (scoreMetaWinter <= PlayerPrefs.GetInt("FallMaxScore"))
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
        if ((PlayerPrefs.GetInt("FallMaxScore") <= 0) && (PlayerPrefs.GetInt("SummerMaxScore") >= scoreMetaFall))
        {
            scoreTextFall.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("FallMaxScore") > 0)
            {
                scoreTextFall.text = " PUNTOS: " + PlayerPrefs.GetInt("FallMaxScore");
            }
            else
            {
                scoreTextFall.text = $" NECESITAS {scoreMetaFall} PUNTOS";
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
        if ((PlayerPrefs.GetInt("WinterMaxScore") <= 0) && (PlayerPrefs.GetInt("FallMaxScore") >= scoreMetaWinter))
        {
            scoreTextWinter.text = " DESBLOQUEADO";
        }
        else
        {
            if (PlayerPrefs.GetInt("WinterMaxScore") > 0)
            {
                scoreTextWinter.text = " PUNTOS: " + PlayerPrefs.GetInt("WinterMaxScore");
            }
            else
            {
                scoreTextWinter.text = $" NECESITAS {scoreMetaWinter} PUNTOS";
            }
        }
        
        // fin Invierno score


        */
        //buttonSummer.interactable = unlockSceneSummer ? true : false;

        //buttonFall.interactable = unlockSceneFall ? true : false;

        //buttonWinter.interactable = unlockSceneWinter ? true : false;
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


    // mejoras del codigo
    public void CheckKeyScoreAndUnlockLevel(string nameKey, int targetScoreNextSeason, Button buttonNextSeason)
    {
        // si ya se creo el PlayerPrefs
        if (PlayerPrefs.HasKey(nameKey))
        {
            // en el caso del ultimo nivel targerScoreNextSeason sera 0
            if (targetScoreNextSeason > 0)
            {
                if (PlayerPrefs.GetInt(nameKey) >= targetScoreNextSeason)
                {
                    // activa el boton
                    buttonNextSeason.interactable = true;
                }
                else
                {
                    buttonNextSeason.interactable = false;
                }
            }
                
        }
        else
        {
            PlayerPrefs.SetInt(nameKey, 0);
            if(targetScoreNextSeason > 0)
            {
                buttonNextSeason.interactable = false;
            }
            
        }

    }

    public void UpdateScoreText(string nameKey, string previousNameKey, int targetScore, TMP_Text textScore )
    {
        // en el caso del primer nivel
        if (previousNameKey == "" || previousNameKey == " ")
        {
            textScore.text = $" PUNTOS: {PlayerPrefs.GetInt(nameKey)}";
        }
        else
        {
            // informar al usuario si se debloqueado el nivel
   
            if ((PlayerPrefs.GetInt(nameKey) <= 0) && (PlayerPrefs.GetInt(previousNameKey) >= targetScore))
            {
                textScore.text = " DESBLOQUEADO";
            }
            else
            {
                if (PlayerPrefs.GetInt(nameKey) > 0)
                {
                    textScore.text = $" PUNTOS: {PlayerPrefs.GetInt(nameKey)}";
                }
                else 
                {
                    textScore.text = $" NECESITAS {targetScore} PUNTOS";
                }
            }
        }
    }
}
