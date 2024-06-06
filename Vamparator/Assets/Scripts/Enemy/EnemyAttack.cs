using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerBloodEvents blood;
    public float attackDelay = 1f;
    EnemySpawn es;
    bool _isWorking = false;

    void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
        es = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!_isWorking && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(enemyAttack());
        }
    }

    IEnumerator enemyAttack()
    {
        _isWorking = true;
        blood.decrease(es.enemyDamage);
        yield return new WaitForSeconds(attackDelay);
        _isWorking = false;
    }
}
