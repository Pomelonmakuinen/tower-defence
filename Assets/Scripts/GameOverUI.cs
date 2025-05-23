using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI roundsText;

    void Start()
    {
        moneyText.text = "Money: $" + PlayerStats.Money;
        roundsText.text = "Rounds Survived: " + WaveSpawner.waveIndex;
    }
}
