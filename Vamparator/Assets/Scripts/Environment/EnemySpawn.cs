using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using Unity.PlasticSCM;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GM;

public class EnemySpawn : MonoBehaviour
{
    [Header("Constant")]
    [SerializeField] private float enemySpawnRate = 1.0f;
    [SerializeField] private int MaxEnemyCount = 10;
    [SerializeField] private float enemySpawnOffset = 20;
    [SerializeField] public float enemySpeed = 2;
    [SerializeField] public float enemyDamage = 5;
    [SerializeField] public float PlayerDamage = 1;
    [SerializeField] public float enemyHealth = 2;
    [SerializeField] public float EnemyRangedDamage = 3;
    [SerializeField] public float EnemyBulletOffsetMultipler = -1;
    [SerializeField] public float EnemyBulletRangeBySecond = 2;
    [SerializeField] public float EnemyBulletSpeed = 2;
    [SerializeField] public float EnemyShootDelay = 2;
    [Space(10)]
    [Header("Real Time Values")]
    [SerializeField] public int CurrentEnemyCount = 0;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private EnemyMeleeAttack attack;
    [SerializeField] GameObject[] enemyTransforms;
    [SerializeField] Text timer;
    [SerializeField] GameObject powerUpText;
    [SerializeField] GameManager gm;
    [Space(10)]
    private bool _isWorking = true;
    private bool _isWorking2 = false;

    int minute = 2;
    int second = 59;
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject RangedEnemyPrefab;
    [SerializeField] public GameObject enemyBullet;

    bool canSpawn = true;
    public bool isDied = false;


    private void Start()
    {
        StartCoroutine(enemySpawn());
        StartCoroutine(timerVoid());
    }


    void Update()
    {
        if (CurrentEnemyCount < MaxEnemyCount && !_isWorking2)
        {
            StartCoroutine(enemySpawn());
        }
    }

    private IEnumerator enemySpawn()
    {
        _isWorking2 = true;

        while (_isWorking && CurrentEnemyCount < MaxEnemyCount)
        {
            float randomSign = Random.value < 0.5f ? -1f : 1f;
            float xOffset = playerPosition.position.x + (randomSign * enemySpawnOffset);
            float randomSignY = Random.value < 0.5f ? -1f : 1f;
            float yOffset = playerPosition.position.y + (randomSignY * enemySpawnOffset);
            float random = Random.Range(0, 6);
            if (canSpawn)
            {
                if (random == 3)
                {
                    Instantiate(RangedEnemyPrefab, new Vector2(xOffset, yOffset), Quaternion.identity);
                }
                else
                {
                    Instantiate(enemyPrefab, new Vector2(xOffset, yOffset), Quaternion.identity);
                }
            }
            CurrentEnemyCount++;
            yield return new WaitForSeconds(enemySpawnRate);
        }

        _isWorking2 = false;
    }

    IEnumerator textShow()
    {
        for (int i = 0; i < 5; i++)
        {
            powerUpText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            powerUpText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator timerVoid()
    {
        while (true)
        {
            second--;
            if (second < 1 && minute > 0)
            {
                second = 59;
                minute--;
                enemySpawnRate -= 0.15f;
                MaxEnemyCount += 50;
                enemySpeed += 0.1f;
                enemyDamage += 3;
                enemyHealth += 15f;
                gm.upgradeNumber += 3;
                StartCoroutine(textShow());
            }
            if (second == 30)
            {
                enemySpawnRate -= 0.15f;
                MaxEnemyCount += 50;
                enemySpeed += 0.1f;
                enemyDamage += 3;
                enemyHealth += 15f;
                gm.upgradeNumber += 3;
                StartCoroutine(textShow());
            }
            if (second < 10)
            {
                timer.text = minute + ":0" + second;
            }
            else
            {
                timer.text = minute + ":"+ second;
            }
            if (minute == 0 && second == 0 && !isDied)
            {
                playerPosition.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                playerPosition.gameObject.GetComponent<Animator>().SetBool("isWon", true);
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
                canSpawn = false;
                foreach (GameObject obj in objects)
                {
                    Destroy(obj);
                }
                playerPosition.gameObject.GetComponent<PlayerMovement>().canMove = false;

                Debug.Log("Oyun bitti");
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(2);
            }
            yield return new WaitForSeconds(1);
        }
        //oyun bitiþ kýsmý ayketincim.
    }

    public void DecreaseEnemyCount()
    {
        CurrentEnemyCount--;
    }
}
