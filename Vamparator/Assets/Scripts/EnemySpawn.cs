using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

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
    [Space(10)]
    private bool _isWorking = true;
    [Header("Prefab")]
    [SerializeField] private GameObject enemyPrefab;
    private void Start()
    {

        StartCoroutine(enemySpawn());
        
    }
    private IEnumerator enemySpawn()
    {
        
        while (_isWorking && CurrentEnemyCount < MaxEnemyCount)
        {
            float randomSign = Random.value < 0.5f ? -1f : 1f;
            float xOffset = playerPosition.position.x + (randomSign * enemySpawnOffset);
            float randomSignY = Random.value < 0.5f ? -1f : 1f;
            float yOffset = playerPosition.position.y + (randomSignY * enemySpawnOffset);
            Instantiate(enemyPrefab, new Vector2(randomSign, randomSignY), Quaternion.identity);
            CurrentEnemyCount++;
            yield return new WaitForSeconds(enemySpawnRate);
        }

    }
    public void DecreaseEnemyCount()
    {
        CurrentEnemyCount--;
    }
}
