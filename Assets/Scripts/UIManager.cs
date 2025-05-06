using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI roundsText;

    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.Money;
        livesText.text = "Lives: " + PlayerStats.Lives;
        roundsText.text = "Rounds: " + PlayerStats.Rounds;
    }
}
