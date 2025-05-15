using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    void Start()
    {
        Money = 100;
        Lives = 10;
    }
}
