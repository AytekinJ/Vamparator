using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollectableFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smooth;
    PlayerBloodEvents playerBloodEvents;
    bool isTouched = false;
    Vector3 velocity = Vector3.zero;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (isTouched)
        {
            Vector3 movePosition = target.position;
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer + " " + LayerMask.NameToLayer("Player"));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            isTouched = true;
            playerBloodEvents = target.GetComponent<PlayerBloodEvents>();
            Destroy(gameObject, 0.2f);
            playerBloodEvents.increase(Random.Range(1, 3) * 10);
        }
    }
}
