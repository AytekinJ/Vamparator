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
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] float lastTimeShooted;
    [SerializeField] PlayerBloodEvents blood;

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
        if (Time.time > lastTimeShooted+shootDelay)
        {
            Vector2 targetPosRot = transform.position - targetEnemy.transform.position;
            GameObject bullet = Instantiate(BulletPrefab,transform.position,Quaternion.identity);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.velocity = targetPosRot.normalized * bulletSpeed;
            Debug.Log("mermi ateşlendi");
            lastTimeShooted = Time.time;
        }
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
        return Vector2.Distance(transform.position, targetEnemy.transform.position) <= MaxDistance;
    }
}