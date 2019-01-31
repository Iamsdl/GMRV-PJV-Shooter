using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    private Rigidbody2D rb;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(0, this.transform.position.y + cameraSpeed,-20);
    }

    private void FixedUpdate()
    {
        cooldown -= Time.fixedDeltaTime;
        if (cooldown <= 0)
        {
            rb.velocity = new Vector2(0, 1.0f);
        }
    }

    public void AlertCamera(float playerSpeed, float playerHeight)
    {
        cooldown = 1.0f;
        if (playerSpeed > rb.velocity.y)
        {
            //rb.velocity = new Vector2(0,((20 - playerHeight) / 5) * playerSpeed);
            rb.velocity = new Vector2(0, playerSpeed);
        }
    }
}
