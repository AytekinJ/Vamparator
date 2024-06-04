using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] float MaxDistance = 1;
    [SerializeField] GameObject[] Enemies;
    [SerializeField] string enemyTag;
    [SerializeField] GameObject targetEnemy;

    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }

    void Update()
    {
        GetEnemies();
        castRay();
        TryAttack();
    }

    void GetEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }

    void TryAttack()
    {
        if (IsCloseEnough())
        {
            Attack();
        }
    }

    void Attack()
    {
        //attır karşim
    }

    void castRay()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        targetEnemy = nearestEnemy != null ? nearestEnemy : null;
    }

    bool IsCloseEnough()
    {
        if (targetEnemy == null)
            return false;
        return Vector2.Distance(transform.position, targetEnemy.transform.position) >= MaxDistance;
    }
}