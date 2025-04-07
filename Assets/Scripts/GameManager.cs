using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 4);
        InvokeRepeating("CreateCoin", 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        // Call magnitude value from the ZigZagMovement script
        ZigZagMovement zigZagScript = enemyTwoPrefab.GetComponent<ZigZagMovement>();
        float magnitude = zigZagScript.magnitude;
        // Prevent off-screen zigzag
        float spawnX = Random.Range(-9f + magnitude, 9f - magnitude);  // Adjusted spawn range
        Instantiate(enemyTwoPrefab, new Vector3(spawnX, 6.5f, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(-9.5f, Random.Range(-3.5f, 1f), 0), Quaternion.identity);
    }

    
}
