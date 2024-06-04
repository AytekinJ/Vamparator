using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    Vector2 movePosition;
    [SerializeField] float speed = 2;
    private void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        movePosition = playerPosition.position - transform.position;
        movePosition = movePosition.normalized;
        transform.Translate(movePosition * Time.deltaTime * speed);
        //transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }
}
