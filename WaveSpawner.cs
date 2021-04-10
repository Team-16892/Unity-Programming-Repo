using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public Text WaveCountdown;

    public float TimeBetweenWaves = 20.9f;
    private float countdown = 3f;

    private int WaveNumber = 0;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
            
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WaveCountdown.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        WaveNumber++;

        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }


}

