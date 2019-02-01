using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private Vector2 bulletAcceleration;
    private float bulletAccelerationMultiplier;
    private Rigidbody2D rb;
    private float bulletLifespan;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletAccelerationMultiplier = 10.0f;
        bulletLifespan = 5.0f;
        StartCoroutine(DeleteBullet());
        this.bulletAcceleration = transform.up * bulletAccelerationMultiplier;
        rb.velocity = Vector2.Dot(owner.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity, transform.right) * 
            (Vector2)transform.right + GameController.TerminalVelocity * (Vector2)transform.up;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.AddForce(bulletAcceleration);
    }

    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(bulletLifespan);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthManager health = collision.gameObject.GetComponent<HealthManager>();
        if (health != null)
        {
            health.TakeDamage(damage, owner);
        }

        Destroy(gameObject);
    }

}
