using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float minSpeed = 10f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float multiplySpeed = 1.01f;

    [SerializeField] private float laneChangeSpeed = 10f;
    [SerializeField] private float laneSize = 2f;



    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool alive = true;


    [SerializeField] private Animator animar;

    [SerializeField] private GameManager manager ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position;
        animar.SetFloat("velocidadX", 0);
        animar.SetFloat("velocidadZ", 0);
        alive = true;
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
        if (!alive) return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) ChangeLane(-1);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ChangeLane(1);

    }

    void ChangeLane(int direction)
    {
        if (!alive) return;

        float targetLane = targetPosition.x + direction * laneSize;

        if (targetLane >= -4f && targetLane <= 4f)
        {
            targetPosition.x = targetLane;
        }
    }


    public void IncreaseSpeed()
    {
        if (!alive) return;

        runSpeed *= multiplySpeed;
        runSpeed = Mathf.Clamp(runSpeed, minSpeed, maxSpeed);
        //runSpeed = (runSpeed >= maxSpeed) ? maxSpeed : runSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Obstacle")) Die();
    }
    public void Die()
    {
        Time.timeScale = 0;

        alive = false;

        manager.Pause();
        
    }

}