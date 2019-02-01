using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public override void Shoot()
    {
        base.Shoot();
        var tempBullet = Instantiate(bullet, transform);
        tempBullet.transform.parent = null;

        tempBullet.gameObject.SetActive(true);
        //tempBullet.gameObject.GetComponent<Rigidbody2D>().velocity = owner.GetComponent<Rigidbody2D>().velocity;
        //tempBullet.owner = owner;
    }
}
