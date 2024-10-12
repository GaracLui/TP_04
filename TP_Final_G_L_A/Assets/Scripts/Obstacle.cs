using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    private void Start()
    {

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }


        // Kill the player
        playerMovement.Die();
  
    }

    private void Update()
    {

    }
}
