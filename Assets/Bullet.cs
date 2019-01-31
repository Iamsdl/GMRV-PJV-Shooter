﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 bulletAcceleration;
    private float bulletAccelerationMultiplier;
    private Rigidbody2D rb;
    private float bulletLifespan;

    public GameObject owner;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bulletAccelerationMultiplier = 10.0f;
        bulletLifespan = 5.0f;
        StartCoroutine(DeleteBullet());
        this.bulletAcceleration = transform.up * bulletAccelerationMultiplier;
        rb.velocity = Vector2.Dot(owner.GetComponent<Rigidbody2D>().velocity,transform.up)*(Vector2)transform.up;
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
