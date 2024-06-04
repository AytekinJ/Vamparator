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
    [Space(10)]
    [Header("Real Time Values")]
    [SerializeField] private int CurrentEnemyCount = 0;
    [SerializeField] private Transform playerPosition;
    [SerializeField] GameObject[] enemyTransforms;
    [SerializeField] Text timer;
    [Space(10)]
    private bool _isWorking = true;
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
    }
    private IEnumerator enemySpawn()
    {
        Debug.Log(Time.deltaTime);
        
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

    }
    public void DecreaseEnemyCount()
    {
        CurrentEnemyCount--;
    }
}
