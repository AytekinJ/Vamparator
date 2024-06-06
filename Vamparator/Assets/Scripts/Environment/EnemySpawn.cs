using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

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
    [Space(10)]
    private bool _isWorking = true;
    private bool _isWorking2 = false;
    private bool increase = true;

    int minute;
    int second;
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject RangedEnemyPrefab;
    [SerializeField] public GameObject enemyBullet;


    private void Start()
    {

        StartCoroutine(enemySpawn());
        
    }


    void Update()
    {
        second = (int)Time.time;
        second -= minute * 60;

        if (second >= 60)
        {
            minute++;
            enemySpawnRate -= 0.05f;
            MaxEnemyCount += 20;
            attack.shootDelay -= 0.05f;
            enemySpeed += 0.5f;
            enemyDamage += 2;
            enemyHealth += 5;
            StartCoroutine(textShow());
            increase = true;
        }

        if (second == 30 && increase)
        {
            enemySpawnRate -= 0.05f;
            MaxEnemyCount += 20;
            attack.shootDelay -= 0.05f;
            enemySpeed += 0.5f;
            enemyDamage += 2;
            enemyHealth += 5;
            StartCoroutine(textShow());
            increase = false;
        }

        if (second<10)
        {
            timer.text = minute + ":0" + second;
        }
        else
        {
            timer.text = minute + ":" + second;
            timer.text = minute + ":" + second;
        }

        if (CurrentEnemyCount < MaxEnemyCount && !_isWorking2)
        {
            StartCoroutine(enemySpawn());
        }
    }

    private IEnumerator enemySpawn()
    {
        Debug.Log(Time.deltaTime);
        _isWorking2 = true;

        while (_isWorking && CurrentEnemyCount < MaxEnemyCount)
        {
            float randomSign = Random.value < 0.5f ? -1f : 1f;
            float xOffset = playerPosition.position.x + (randomSign * enemySpawnOffset);
            float randomSignY = Random.value < 0.5f ? -1f : 1f;
            float yOffset = playerPosition.position.y + (randomSignY * enemySpawnOffset);
            float random = Random.Range(0, 3);
            if (random == 1)
            {
                Instantiate(RangedEnemyPrefab, new Vector2(xOffset, yOffset), Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefab, new Vector2(xOffset, yOffset), Quaternion.identity);
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

    public void DecreaseEnemyCount()
    {
        CurrentEnemyCount--;
    }
}
