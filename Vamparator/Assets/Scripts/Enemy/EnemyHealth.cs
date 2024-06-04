using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;
    [SerializeField] float baseDamage = 10;
    [SerializeField] LayerMask meleeAttackLayer;
    [SerializeField] LayerMask weaponAttackLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Çarpýþma");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Mermi yok edildi");
            enemyHealth -= baseDamage;
            Debug.Log("Can azaldý");
            if (enemyHealth < 0)
            {
                Destroy(gameObject);
            }
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
