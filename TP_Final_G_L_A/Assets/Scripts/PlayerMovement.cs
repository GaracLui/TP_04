using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float runSpeed = 10f;
    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    public float laneChangeSpeed = 10f;
    public float laneSize = 2f;

    private Rigidbody rb;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }



    private void Update()
    {
        MoveCharacter();

       
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * runSpeed;
    }

    void MoveCharacter()
    {
        HandleKeyboard();
        Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        transform.localPosition = Vector3.MoveTowards(transform.position, newPosition, laneChangeSpeed * Time.deltaTime);
    }

    void HandleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);

    }

    void ChangeLane(int direction)
    {
        float targetLane = targetPosition.x + direction * laneSize;

        if (targetLane >= -4f && targetLane <= 4f)
        {
            targetPosition.x = targetLane;
        }
    }


    public void IncreaseSpeed()
    {
        runSpeed *= 1.1f;
        runSpeed = (runSpeed >= maxSpeed) ? maxSpeed : runSpeed;
    }
}