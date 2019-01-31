using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : InteractionObject
{
    public Item item;
    public override void Interaction()
    {
        base.Interaction(); // se apeleaza metoda parinte, in caz ca avem ceva generic

        //mecanica
        InventoryManager.instance.Add(item);    
        
        //distrugem obiectul
        Destroy(gameObject);
    }
}