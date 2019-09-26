using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ThrowableGameObj : MonoBehaviour
{
    private GameObject tilemap;
    private bool madeSound = false;

    [SerializeField]
    private GameObject soundsrc;

    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        tilemap = FindObjectOfType<Tilemap>().gameObject;
    }

    private void Update()
    {
        RemoveStoppedObj();
    }

    //Temp method for testing object.
    private void RemoveStoppedObj()
    {
        if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude < 0.1f)
        {
            MakeSound();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == tilemap)
        {
            MakeSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!list.Contains(collision.gameObject) && collision.gameObject.GetComponent<HearRange>())
        {
            list.Add(collision.gameObject);
        }
    }

    private void MakeSound()
    {
        if(!madeSound)
        {
            foreach (GameObject go in list)
            {
                var sSrc = Instantiate(soundsrc, this.transform.position, Quaternion.identity, go.transform);

                print(go);
                //go.GetComponent<HearRange>
            }
        }
        madeSound = true;

        Destroy(this.gameObject, 3);//Temp
    }
}
