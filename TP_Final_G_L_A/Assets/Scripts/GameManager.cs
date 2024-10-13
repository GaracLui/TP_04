using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

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

    private void Start()
    {
       
    }

    private void Update()
    {

    }
}
