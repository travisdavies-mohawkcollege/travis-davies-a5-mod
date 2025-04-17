using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float thrust = 3;
    [SerializeField] private float rotationSpeed = 360;
    [SerializeField] private float maxVelocity = 15;
    [SerializeField] private float bulletSpeed = 3;
    [SerializeField] private float bulletLifetime = 1;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerSpawn1;
    [SerializeField] private GameObject playerSpawn2;
    [SerializeField] private GameObject playerSpawn3;
    [SerializeField] private GameObject playerSpawn4;
    [SerializeField] private GameObject thisPlayer;
    [SerializeField] public HyperspaceManager hyperspaceManager;
    public bool canShoot;
    private int arena;
    private Vector3 playerPos;


    private void Awake()
    {
        playerPos = thisPlayer.transform.position;
        // Check which arena the player is in
        if (playerPos == playerSpawn1.transform.position)
        {
            arena = 1;
        }
        else if (playerPos == playerSpawn2.transform.position)
        {
            arena = 2;
        }
        else if (playerPos == playerSpawn3.transform.position)
        {
            arena = 3;
        }
        else if (playerPos == playerSpawn4.transform.position)
        {
            arena = 4;
        }
    }



    private void Update()
    {
        
        // Spawn bullet on mouse click
        int leftClickID = 0;
        if (Input.GetMouseButtonDown(leftClickID) && arena == hyperspaceManager.currentArena)
        {
            // Bullet transform information when spawned
            Vector3 pos = transform.position + transform.up;
            Quaternion rot = Quaternion.identity;

            // Create a clone of bullet object
            GameObject bullet = Instantiate(bulletPrefab, pos, rot);
            Rigidbody2D bulletRB2D = bullet.GetComponent<Rigidbody2D>();

            // Shoot bullet in facing direction
            Vector2 force = transform.up * bulletSpeed;
            bulletRB2D.AddForce(force, ForceMode2D.Impulse);

            // Destroy bullet after this much time
            Destroy(bullet, bulletLifetime);
        }
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        // Forcibly rotate player when using left-right inputs
        float rotationAngle = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;    
        rb2d.MoveRotation(rotationAngle + transform.rotation.eulerAngles.z);

        // Add force to player
        if (Input.GetKey(KeyCode.Space))
        {
            // Cap movement speed
            bool canApplyVelocity = rb2d.linearVelocity.magnitude < maxVelocity;
            if (canApplyVelocity)
            {
                Vector2 thrustForce = transform.up * thrust;
                rb2d.AddForce(thrustForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //Asteroid asteroid = collider2D.GetComponent<Asteroid>();
        //if (asteroid == null)
        //    return;

        // Don't run code past this check if not an asteroid
        bool isAsteroid = collider2D.gameObject.CompareTag("Asteroid");
        if (!isAsteroid)
            return;

        // Lose a life, handle case when lives run out
        gameManager.RemoveLife();
        if (gameManager.IsGameOver())
        {
            // Destroy player -- code stops running after this!
            Destroy(this.gameObject);
        }

        // Reset player position
        //rb2d.MovePosition(Vector2.zero);
        if (arena == 1)
        {
            rb2d.MovePosition(playerSpawn1.transform.position);
        }
        else if (arena == 2)
        {
            rb2d.MovePosition(playerSpawn2.transform.position);
        }
        else if (arena == 3)
        {
            rb2d.MovePosition(playerSpawn3.transform.position);
        }
        else if (arena == 4)
        {
            rb2d.MovePosition(playerSpawn4.transform.position);
        }


        // Reset asteroids...
    }
}
