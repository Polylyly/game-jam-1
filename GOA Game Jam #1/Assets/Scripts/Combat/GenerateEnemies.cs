using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemyObject;
    public int enemyCountCarryover;
    public int enemyCountStart;
    public static int currentEnemyCount;
    public int baseEnemyCount;
    public int enemyMultiplier;


    private int xMin;
    private int xMax;
    private int zMin;
    private int zMax;
    private int xCurrentPos;
    private int zCurrentPos;

    void Start()
    {
        xMin = -12;
        xMax = 12;
        zMin = -12;
        zMax = 12;
        getNumbersFromLastRound();

        baseEnemyCount = 3;
        enemyCountStart = (baseEnemyCount * enemyMultiplier) + enemyCountCarryover;
        print(enemyCountStart);
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {
        currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator EnemySpawn()
    {
        int temp = 0;
        while (temp < enemyCountStart)
        {
            xCurrentPos = Random.Range(xMin, xMax + 1);
            zCurrentPos = Random.Range(zMin, zMax + 1);
            Instantiate(enemyObject, new Vector3(xCurrentPos, 3f, zCurrentPos), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
            temp += 1;
            print("done");
        }
    }

    public void getNumbersFromLastRound()
    {
        enemyCountCarryover = ChangeScene.enemiesLeftFromPrevious;
    }
}
