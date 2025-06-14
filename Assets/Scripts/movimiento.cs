using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int lives = 3;
    public int score = 0;
    private Vector3 initialPosition;
    private Vector3 currentDirection;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        if (currentDirection != Vector3.zero)
        {
            rb.MovePosition(transform.position + currentDirection * speed * Time.fixedDeltaTime);
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            currentDirection = Vector3.forward;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            currentDirection = Vector3.back;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            currentDirection = Vector3.left;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            currentDirection = Vector3.right;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            currentDirection = Vector3.zero;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            lives--;
            transform.position = initialPosition;
            // Actualizar UI aquí
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            score++;
            Destroy(other.gameObject);
            // Actualizar UI aquí
        }
    }
}
