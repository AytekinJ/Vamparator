using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    [SerializeField] float baseDamage;
    [SerializeField] LayerMask meleeAttackLayer;
    [SerializeField] LayerMask weaponAttackLayer;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject Blood;
    PlayerBloodEvents blood;
    EnemySpawn enemySpawn;

    private void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
        enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
        enemyHealth = enemySpawn.enemyHealth;
        baseDamage = enemySpawn.PlayerDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            enemyHealth -= baseDamage;

            if (enemyHealth < 0)
            {
                enemySpawn.CurrentEnemyCount--;
                float randomNum = Random.Range(0, 2);

                if (randomNum == 1)
                {
                    Instantiate(Blood, transform.position, Quaternion.identity);
                }

                GameManager.Score++;

                Destroy(gameObject);
            }

            Rigidbody bulletrb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 instantiatePos = new Vector3(transform.position.x,transform.position.y,-2);
            GameObject effect = Instantiate(hitEffect,instantiatePos,Quaternion.identity);
            Destroy(effect,1);
        }
        
    }
}
