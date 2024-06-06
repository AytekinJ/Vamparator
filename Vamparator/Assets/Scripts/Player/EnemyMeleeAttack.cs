using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float MaxDistance = 1;
    [SerializeField] GameObject[] Enemies;
    [SerializeField] string enemyTag;
    [SerializeField] GameObject targetEnemy;
    [SerializeField] GameObject BulletPrefab;
    public float bulletSpeed;
    public float bulletRangeBySecond = 1.5f;
    public float shootDelay = 1f;
    [SerializeField] float lastTimeShooted;
    [SerializeField] float offsetMultipler = -2;

    Animator animator;

    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        animator = GetComponent<Animator>();
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
        if (Time.time > lastTimeShooted + shootDelay)
        {
            Vector3 targetPosRot = transform.position - targetEnemy.transform.position;

            Vector2 direction = (transform.position - targetEnemy.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject bullet = Instantiate(BulletPrefab, transform.position + targetPosRot.normalized * offsetMultipler, lookRotation);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();

            bulletrb.velocity = targetPosRot.normalized * bulletSpeed;

            Destroy(bullet, bulletRangeBySecond);
            lastTimeShooted = Time.time;
            animator.SetTrigger("Shoot");
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