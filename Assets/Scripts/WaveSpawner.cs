using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform[] enemyPrefabs;
    public Transform spawnPoint;

    [Header("Wave Settings")]
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    public static int waveIndex = 0;

    [Header("UI")]
    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI roundText;

    [Header("Dialogue")]
    public DialogueManager dialogueManager;
    public List<string> dialogueLines;

    private bool dialogueTriggered = false;

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

        // Trigger dialogue on wave 3
        if (waveIndex == 3 && !dialogueTriggered && dialogueManager != null && dialogueLines.Count > 0)
        {
            dialogueManager.StartDialogue(dialogueLines);
            dialogueTriggered = true;
        }

        for (int i = 0; i < waveIndex; i++)
        {
            Transform enemyToSpawn = SelectEnemyToSpawn();
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
            SFXManager.Instance.PlayEnemySpawn();
            yield return new WaitForSeconds(1f);
        }
    }

    Transform SelectEnemyToSpawn()
    {
        if (waveIndex % 3 == 1)
            return enemyPrefabs[0]; // Normal
        else if (waveIndex % 3 == 2)
            return enemyPrefabs[1]; // Fast
        else
            return enemyPrefabs[2]; // Tank
    }
}
