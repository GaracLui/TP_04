using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static MainMenu inst;

    // Start is called before the first frame update
    public bool unlockScene2 = false;
    [SerializeField] private int scoreMeta2 = 30;
    [SerializeField] private UnityEngine.UI.Button buttonSummer;

    public bool unlockScene3 = false;
    [SerializeField] private int scoreMeta3 = 50;
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

        buttonSummer.interactable = unlockScene2 ? true : false;

        buttonFall.interactable = unlockScene3 ? true : false;

        buttonWinter.interactable = unlockScene4 ? true : false;
    }

    public void  UnlockNextLevel(int score, int levelIndex)
    {
        switch (levelIndex)
        {
            case 1:
                if (score >= scoreMeta2) unlockScene2 = true;
                break;
            case 2:
                if (score >= scoreMeta3) unlockScene3 = true;
                break;
            case 3:
                if (score >= scoreMeta4) unlockScene4 = true;
                break;
            default:
                break;
        }
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
}
