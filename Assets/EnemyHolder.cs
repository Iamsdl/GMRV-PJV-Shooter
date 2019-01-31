using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{

    private GameObject target;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            //rb.angularVelocity = 5;
            rb.velocity = (target.transform.position - transform.position) / (10 * Time.fixedDeltaTime);
        }
    }

   public void ChangeTarget(GameObject target)
    {
        this.target = target;
    }
}
