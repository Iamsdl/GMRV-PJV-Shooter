using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public float radius = 1f;
    Transform interactionPoint;
    Transform interactionObject;
    bool done = false;

    //metoda abstracta, speficica fiecarui tip de interactiuni
    public virtual void Interaction()
    {

    }

    protected virtual void Start()
    {
        interactionObject = transform;
        interactionPoint = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            float distance = Vector3.Distance(interactionObject.position, interactionPoint.position);

            if (distance <= radius && !done) // avem interactiune cu obiectul
            {
                Interaction();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(interactionPoint.position, radius);
    }
}