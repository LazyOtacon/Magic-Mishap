using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // "Public" Variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject missileSpawn;
    [SerializeField] private float fireRate;

    // Private Variables
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Physics (Update is called once per frame)
    private void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        rBody.velocity = new Vector2(hori * speed, rBody.velocity.y);

        // Jump
        if(isGrounded && (Input.GetAxis("Jump") > 0))
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        // Check if the "Fire" button is pressed
        if ((Input.GetAxis("Fire1") > 0) && (timer > fireRate))
        {
            // If yes, spawn the laser
            GameObject.Instantiate(missile, missileSpawn.transform.position, missileSpawn.transform.rotation);

            // Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    // Detect when the enemy collides with the player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}