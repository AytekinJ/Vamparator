using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerBloodEvents blood;
    void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
    }
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
}
