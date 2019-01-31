using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject asteroid;
    private float probMult;

    // Start is called before the first frame update
    void Start()
    {
        probMult = GameController.difficulty / 128;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var y = Mathf.Log(this.transform.position.y, 10) * probMult;
        var x = UnityEngine.Random.Range(0.0f, 1.0f);
        if (x <= y)
        {
            var z = Mathf.Log(this.GetComponentInParent<Rigidbody2D>().velocity.y, 10);
            var extra = UnityEngine.Random.Range(0.0f, z) * GameController.difficulty;
            for (int i = 0; i <= Mathf.Floor(extra); i++)
            {
                SapwnAsteroid();
            }
        }

    }

    private void SapwnAsteroid()
    {
        GameObject tempAsteroid = Instantiate(asteroid);
        tempAsteroid.transform.position = new Vector3(UnityEngine.Random.Range(-50.0f, 50.0f), this.transform.position.y, 0);
        var radius = Mathf.Clamp(Random.Range(0, 2) * GameController.difficulty, 1, 4);
        tempAsteroid.transform.localScale = new Vector3(radius, radius, 1);
        tempAsteroid.GetComponent<HealthManager>().maxHealth *= radius * radius;
        tempAsteroid.SetActive(true);
    }
}
