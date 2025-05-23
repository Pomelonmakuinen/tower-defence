using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public Transform[] enemyPrefabs; // Assign multiple enemies here in Inspector
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
    private bool dialogueShown = false;

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

        if (waveIndex == 5 && !dialogueShown)
        {
            ShowDialogue();
            dialogueShown = true;
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

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
        if (waveIndex < 3)
            return enemyPrefabs[0]; // Normal enemy
        else if (waveIndex < 6)
            return enemyPrefabs[1]; // Fast enemy
        else
            return enemyPrefabs[2]; // Tank enemy
    }

    void ShowDialogue()
    {
        var lines = new System.Collections.Generic.List<string>
        {
            "Hold on...",
            "That last wave was tougher than expected.",
            "Something big might be coming."
        };

        dialogueManager.StartDialogue(lines);
    }
}
