using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ViewRange : MonoBehaviour
{
    [SerializeField]
    private TempAI ai;
    private GameObject pc;
    private GameObject tilemap;

    private List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        pc = FindObjectOfType<CharacterMovement>().gameObject;
        tilemap = FindObjectOfType<Tilemap>().gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == pc)
        {
            RaycastHit2D[] results = Physics2D.RaycastAll(transform.position, (pc.transform.position - transform.position).normalized, Vector2.Distance(pc.transform.position, transform.position));
            Debug.DrawRay(transform.position, pc.transform.position - transform.position, Color.yellow, 0.1f);

            foreach (RaycastHit2D result in results)
            {
                if (list.Contains(result.collider.gameObject) == false)
                {
                    list.Add(result.collider.gameObject);
                }
            }
            if (list.Contains(tilemap) == false && list.Count != 0)
            {
                ai.SetGoal(pc.GetComponent<CharacterMovement>().GetPlayerPosition());
                ai.pcIsInView = true;
            }
            else
            {
                ai.SetGoal(null);
                ai.pcIsInView = false;
            }
            list.Clear();//Can be optimized.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ai.SetGoal(null);
        ai.pcIsInView = false;
    }
}
