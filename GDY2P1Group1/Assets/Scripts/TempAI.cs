using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TempAI : MonoBehaviour
{
    [SerializeField]
    private GameObject tilemap;
    private GameObject pc;

    private CapsuleCollider2D visableArea;

    private bool foundPlayer = false;
    public bool pcIsInView = false;

    private Transform goal;

    private void Start()
    {
        pc = FindObjectOfType<CharacterMovement>().gameObject;
        visableArea = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (GetComponent<AIDestinationSetter>().target)
        {
            foundPlayer = true;
        }
        else
        {
            foundPlayer = false;
        }
    }

    public void SetGoal(Transform g)
    {
        goal = g;
        GetComponent<AIDestinationSetter>().target = goal;
    }
}