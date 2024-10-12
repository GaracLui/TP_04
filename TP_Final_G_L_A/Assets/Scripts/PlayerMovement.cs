using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    
    public float runSpeed = 10f;
    public float minSpeed = 10f;
    public float maxSpeed = 30f;
    public float laneChangeSpeed = 10f;
    public float laneSize = 2f;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool alive = true;

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
        if (!alive) return;

        rb.velocity = Vector3.forward * runSpeed;
    }

    void MoveCharacter()
    {
        if (!alive) return;

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
        runSpeed *= 1.01f;
        runSpeed = (runSpeed >= maxSpeed) ? maxSpeed : runSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Obstacle")) Die();
    }
    public void Die()
    {
        Time.timeScale = 0;
        runSpeed = 0;
        alive = false;
        
    }

}