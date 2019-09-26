using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public GameObject parentObject;
    public int id;
    public string name;
    public Sprite sprite;
    
    public void getParentObject(GameObject parentObject)
    {
        //method that will find the prefab that is the parent to the pickupItem
    }
}
