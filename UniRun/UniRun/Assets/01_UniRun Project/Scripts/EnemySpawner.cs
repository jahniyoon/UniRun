using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] enemies;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25f);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, poolPosition, Quaternion.identity); // identity �� ������ �ʱ�ȭ�ϱ����� ���.
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);
            enemies[currentIndex].SetActive(false);
            enemies[currentIndex].SetActive(true);    // �ѹ� ���� Ű�� ����.
            enemies[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }
        }
    }
}
