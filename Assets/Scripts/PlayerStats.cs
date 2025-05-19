using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startMoney = 100;

    void Start()
    {
        Money = startMoney;
        Lives = 10;
    }
}
