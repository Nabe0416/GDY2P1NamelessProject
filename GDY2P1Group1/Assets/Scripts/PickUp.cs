using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Item pickup;
    private GameObject go;
    private Inventory i;

    private void Start()
    {
        i = FindObjectOfType<Inventory>();
        go = FindObjectOfType<CharacterMovement>().gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("start collide with object");
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == go)
        {
            //check for GO == player
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pickup");
                i.AddItem(pickup);
                gameObject.SetActive(false);
            }
        }
    }
}
