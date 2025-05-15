using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;
    public TextMeshProUGUI roundText;


    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();

        roundText.text = "Round: " + waveIndex;

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

        // Trigger dialogue AFTER spawning a specific wave
        if (waveIndex == 3)
        {
            List<string> lines = new List<string>()
        {
            "You're doing great so far!",
            "But be careful, stronger enemies are coming...",
        };

            FindObjectOfType<DialogueManager>().StartDialogue(lines);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}