using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] float radius = 1;
    [SerializeField] LayerMask EnemyLayerMask;
    [SerializeField] private GameObject target;
    void Start()
    {

    }
    void Update()
    {
        castRay();
        if (target is not null)
        { 
            Debug.DrawLine(transform.position,target.transform.position,Color.red);
        }
    }
    void castRay()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, radius);
        float minDistance = 5f;
        Collider2D closest = null;
        foreach (Collider2D r in results)
        {
            float distance = Vector2.Distance(transform.position, r.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = r;
            }
        }
        if (closest != null)
        {
            target = closest.gameObject;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}