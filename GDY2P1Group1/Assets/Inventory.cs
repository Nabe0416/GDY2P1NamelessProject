using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public int maxInventorySize;
    public int selectedItem;
    private GameObject go;
    private void Start()
    {
        go = FindObjectOfType<CharacterMovement>().gameObject;
    }

    public void AddItem(Item item)
    {
        if (itemList.Count < maxInventorySize)
        {
            itemList.Add(item);
        }
        else
        {
            DropSelectedItem();
            itemList.Insert(selectedItem-1, item);
        }


    }

    public void DropSelectedItem()
    {
        Instantiate(itemList[selectedItem - 1].parentObject, go.transform.position, go.transform.rotation);
        RemoveItem(itemList[selectedItem - 1]);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 1;
            Debug.Log(selectedItem);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (itemList.Count >= 2)
            {
                selectedItem = 2;
                Debug.Log(selectedItem);
            }
            else
            {
                selectedItem = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (itemList.Count == 3)
            {
                selectedItem = 3;
                Debug.Log(selectedItem);
            }
            else
            {
                selectedItem = itemList.Count;
            }
        }
        if (itemList.Count > 0)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DropSelectedItem();
                if (selectedItem > itemList.Count)
                {
                    selectedItem = itemList.Count;
                }
            }
        if(selectedItem == 0 && itemList.Count > 0)
        {
            selectedItem = 1;
        }
        //if (itemList[selectedItem-1] == Throwable){ //throwItem
        //if (Input.GetMouseButtonDown(1)) //right click
        //{
            //DropSelectedItem & rigidBody addforce (25/weight)
        //}
        //}
    }
}
