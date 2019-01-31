using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject fuelPickup;
    public GameObject healthBar;
    public float maxHealth;
    private float currentHealth;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage, GameObject owner)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            var ship = this.gameObject.GetComponent<Ship>();
            if (ship != null)
            {
                var tempFuelPickup = Instantiate(fuelPickup);
                tempFuelPickup.GetComponent<FuelPickup>().amount = ship.Fuel;
                tempFuelPickup.SetActive(true);
            }
            else if (this.gameObject.GetComponent<Enemy>() != null)
            {
                var tempFuelPickup = Instantiate(fuelPickup);
                tempFuelPickup.GetComponent<FuelPickup>().amount = Random.Range(0.0f, 1.0f);
                tempFuelPickup.transform.position = this.transform.position;
                tempFuelPickup.SetActive(true);
            }
            Destroy(this.gameObject);

            Ship ownerShip = owner.GetComponent<Ship>();
            if (ownerShip != null)
            {
                ownerShip.AddScore(maxHealth);
            }
        }

        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb2 = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 resultant = rb.velocity - rb2.velocity;
        TakeDamage(rb2.mass / (rb.mass + rb2.mass) * resultant.magnitude, collision.gameObject);
    }
}
