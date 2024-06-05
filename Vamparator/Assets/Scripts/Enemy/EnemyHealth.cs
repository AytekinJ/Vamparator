using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;
    [SerializeField] LayerMask meleeAttackLayer;
    [SerializeField] LayerMask weaponAttackLayer;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject Blood;
    PlayerBloodEvents blood;
    EnemySpawn es;
    private void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
        es = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= es.baseDamage;
            if (enemyHealth < 0)
            {
                Destroy(gameObject);
                es.CurrentEnemyCount--;
                float random = Random.Range(1, es.ChanceofBlood);
                if (random == 2)
                {
                    Instantiate(Blood, transform.position, Quaternion.identity);
                }
            }
            Rigidbody bulletrb = collision.gameObject.GetComponent<Rigidbody>();
            GameObject effect = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(effect,1);
        }
        
    }
}
