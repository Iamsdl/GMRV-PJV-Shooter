using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    public Weapon weapon;
    private float attackSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = 6.0f / (GameController.difficulty + 1);
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        #region Shooting
        if (attackSpeed > 0)
        {
            attackSpeed -= Time.fixedDeltaTime;
        }
        else
        {
            if (target != null)
            {
                weapon.Shoot();
                attackSpeed = 6.0f / (GameController.difficulty + 1);
            }
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ship = collision.GetComponent<Ship>();
        if (ship != null)
        {
            if (target == null)
            {
                target = ship.gameObject;
                transform.parent.GetComponent<EnemyHolder>().ChangeTarget(target);
            }
            else
            {
                if ((target.transform.position - transform.position).magnitude > (ship.transform.position - transform.position).magnitude)
                {
                    target = ship.gameObject;
                    transform.parent.GetComponent<EnemyHolder>().ChangeTarget(target);
                }
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(this.transform.parent.gameObject);
    }


}
