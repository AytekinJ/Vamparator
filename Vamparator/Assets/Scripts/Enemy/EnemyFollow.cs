using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Rigidbody2D enemyrb;
    EnemySpawn es;
    Vector2 movePosition;

    private void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
        es = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySpawn>();
        enemyrb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movePosition = playerPosition.position - transform.position;
        movePosition = movePosition.normalized;
        enemyrb.velocity = movePosition * es.enemySpeed;
    }
}
