using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;

    void Update()
    {
        moneyText.text = "Money: " + PlayerStats.Money;
        livesText.text = "Lives: " + PlayerStats.Lives;
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
