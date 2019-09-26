using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private GameObject tilemap;
    private GameObject pc;

    [SerializeField]
    private ViewRange vr;
    [SerializeField]
    private HearRange hr;

    public bool pcIsInView = false;

    private Transform viewPos;
    private Transform hearPos;

    [SerializeField]
    private Transform lastSeenPos;

    private void Start()
    {
        pc = FindObjectOfType<CharacterMovement>().gameObject;
        tilemap = FindObjectOfType<Tilemap>().gameObject;
    }

    private void Update()
    {
        if(viewPos != null)
        {
            pcIsInView = true;
        }
        else
        {
            pcIsInView = false;
        }
    }

    public void SeePlayerAt(Transform pos)
    {
        viewPos = pos;
        GetComponent<AIDestinationSetter>().target = viewPos;

        ChasePlayerMode();
    }

    public void HearSmtAt(Transform pos)
    {
         
    }

    public void ShootPlayer()
    {

    }

    private void ChasePlayerMode()
    {
        GetComponent<AIPath>().maxSpeed = 3;
    }
}