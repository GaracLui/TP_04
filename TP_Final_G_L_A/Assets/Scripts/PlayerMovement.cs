using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneWidth = 2f;
    public float moveSpeed = 10f;

    private float targetLane = 0f;
    private float currentLane = 0f;

    void Update()
    {
        // Handle input
        if (Input.GetKeyDown(KeyCode.A))
        {
            // no se pone en -4 porque al utilizar MathfLerp termina cambiando su posición en por ejemplo -3.993
            if(currentLane >= -3)
            {
                targetLane -= laneWidth;
            }
          
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // no se pone en 4 porque al utilizar MathfLerp termina cambiando su posición en por ejemplo -3.993
            if (currentLane <= 3)
            {
                targetLane += laneWidth;
            }
        }

        // Move towards target lane
        currentLane = Mathf.Lerp(currentLane, targetLane, moveSpeed * Time.deltaTime);

        // Apply movement to the player's position
        transform.position = new Vector3(currentLane, transform.position.y, transform.position.z);
    }
}
