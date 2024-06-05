using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;
    [SerializeField] float baseDamage = 10;
    [SerializeField] LayerMask meleeAttackLayer;
    [SerializeField] LayerMask weaponAttackLayer;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject Blood;
    PlayerBloodEvents blood;
    private void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= baseDamage;
            if (enemyHealth < 0)
            {
                Destroy(gameObject);
                Instantiate(Blood,transform.position,Quaternion.identity);
            }
            Rigidbody bulletrb = collision.gameObject.GetComponent<Rigidbody>();
            GameObject effect = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(effect,1);
        }
        
    }
}
