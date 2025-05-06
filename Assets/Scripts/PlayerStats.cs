using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int Rounds;

    void Start()
    {
        Money = 100;
        Lives = 10;
        Rounds = 0;
    }
}
