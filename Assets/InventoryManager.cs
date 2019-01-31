using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    // singleton
    public static InventoryManager instance;
    void Awake()
    {
        instance = this;
    }

    //lista de obiecte
    public List<Item> items = new List<Item>();

    public delegate void OnInventoryAdd(Item item);
    public OnInventoryAdd onInventoryAddCallback;

    public delegate void OnInventoryRemove();
    public OnInventoryRemove onInventoryRemoveCallback;

    //metode pentru gestionare
    public void Add(Item item)
    {
        items.Add(item);
        onInventoryAddCallback.Invoke(item);
    }

    public void Remove()
    {
        Item item = items[items.Count - 1];
        Transform transform1 = GameObject.FindGameObjectWithTag("marker").transform;
        Instantiate(item.gameObject, transform1.position,transform1.rotation);


        items.Remove(item);
        onInventoryRemoveCallback.Invoke();
    }

}