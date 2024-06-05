using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerBloodEvents blood;
    [SerializeField] float baseDamage = 10;
    [SerializeField] float attackDelay = 1f;
    bool _isWorking = false;
    void Start()
    {
        blood = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBloodEvents>();
    }
    void Update()
    {
        
    }
    IEnumerator enemyAttack()
    {
        _isWorking = true;
        blood.decrease(Random.Range(1, 3) * baseDamage);
        yield return new WaitForSeconds(attackDelay);
        _isWorking = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!_isWorking && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(enemyAttack());
        }
    }
}
