using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EnemySpawn enemySpawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
            PlayerBloodEvents pbe = collision.gameObject.GetComponent<PlayerBloodEvents>();
            Destroy(gameObject);
            pbe.decrease(enemySpawn.enemyRangedDamage);
        }
    }
}
