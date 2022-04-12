using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 5.5f;

    public Transform spawnPoint;

    public Text waveCountdownText;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0.2)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        waveCountdownText.text = Mathf.Round(countdown).ToString();

        countdown -= Time.deltaTime;


    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incomming");
        
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
