using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool gameIsPaused;
    public Rigidbody2D rb;
    public float playerSpeed = 1;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (gameIsPaused == false)
        {
            rb.velocity = playerSpeed * Time.fixedDeltaTime * movement.normalized;
        }
        
    }
}
