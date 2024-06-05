using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float enemySpawnRate = 1.0f;
    [SerializeField] private int MaxEnemyCount = 10;
    [SerializeField] private float enemySpawnOffset = 20;
    [SerializeField] public int CurrentEnemyCount = 0;
    [SerializeField] GameObject[] enemyTransforms;
    [Space(10)]
    [Header("Blood")]
    [SerializeField] public float baseDamage = 10;
    [SerializeField] public float healMultipler = 5;
    [SerializeField] public float ChanceofBlood = 3;
    [SerializeField] public float decreaseAmount = 5;
    [SerializeField] public float decreaseRate = 0.5f;
    [Space(10)]
    [Header("Real Time Values")]
    [SerializeField] private Transform playerPosition;
    [SerializeField] private EnemyMeleeAttack attack;
    [SerializeField] Text timer;
    [Space(10)]
    private bool _isWorking = true;
    private bool _isWorking2 = false;
    private bool increase = true;
    int minute;
    int second;
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;
    private void Start()
    {

        StartCoroutine(enemySpawn());
        
    }
    private void Update()
    {
        second = (int)Time.time;
        second -= minute * 60;
        if (second >= 60)
        {
            minute++;
            enemySpawnRate -= 0.05f;
            MaxEnemyCount += 20;
            attack.shootDelay -= 0.05f;
            increase = true;
        }
        if (second == 30 && increase)
        {
            enemySpawnRate -= 0.05f;
            MaxEnemyCount += 20;
            attack.shootDelay -= 0.05f;
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
            Instantiate(enemyPrefab, new Vector2(xOffset,yOffset), Quaternion.identity);
            CurrentEnemyCount++;
            yield return new WaitForSeconds(enemySpawnRate);
        }
        _isWorking2 = false;
    }
    public void DecreaseEnemyCount()
    {
        CurrentEnemyCount--;
    }
}
