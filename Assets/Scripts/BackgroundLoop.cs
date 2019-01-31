using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y-mainCamera.transform.position.y<-60)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 120, 0);
        }
    }
}
