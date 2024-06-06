using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyMovement : MonoBehaviour
{
    GameObject player;
    float distance;
    Vector2 moveDirection;
    EnemySpawn es;
    Rigidbody2D rb;
    float lastTimeShooted;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        es = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        MovePositionSet();
        if (distance < 3)
        {
            rb.velocity = moveDirection * es.enemySpeed;
            animator.SetBool("isWalking", true);
        }
        else if (distance > 4)
        {
            rb.velocity = -moveDirection * es.enemySpeed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
        Shoot();

        spriteRenderer.flipX = rb.velocity.x < 0 ? true : false;
    }

    private void MovePositionSet()
    {
        moveDirection = transform.position - player.transform.position;
        moveDirection = moveDirection.normalized;
    }
    private void Shoot()
    {
        if (Time.time > lastTimeShooted + es.EnemyShootDelay)
        {
            Vector3 targetPosRot = transform.position - player.transform.position;
            GameObject bullet = Instantiate(es.enemyBullet, transform.position + targetPosRot.normalized * es.EnemyBulletOffsetMultipler, Quaternion.identity);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.velocity = targetPosRot.normalized * es.EnemyBulletSpeed;
            Destroy(bullet, es.EnemyBulletRangeBySecond);
            lastTimeShooted = Time.time;
        }
    }
}
