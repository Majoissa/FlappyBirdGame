using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int poolSize = 5;
    private GameObject[] obstacles;
    public float spawnTime = 6f; //tiempo para que aparezcan los obstaculos;
    public float xSpawnPosition = 20f;
    public float yminPosition = -2f;
    public float ymaxPosition = 3f;
    public float timeElapsed; //para guardar el tiempo desde la ultima aparicion de un obstaculo
    private int obstacleCount;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[poolSize];
        for (int i= 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTime && !GameManager.Instance.isGameOver) //si el tiempo transcurrido es mayor al tiempod e aparicion, llamo a la funcion spawn obstacle
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        timeElapsed = 0f;

        float ySpawnPosition = Random.Range(yminPosition, ymaxPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if(!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true); 
        }
        
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
