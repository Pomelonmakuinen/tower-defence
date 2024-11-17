using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one buildmanager :-D");
        }

        instance = this;
    }

    public GameObject standardSprinklerPrefab;

    void Start()
    {
        sprinklerToBuild = standardSprinklerPrefab;
    }

    private GameObject sprinklerToBuild;

    public GameObject GetSprinklerToBuild()
    {
        return sprinklerToBuild;
    }
}
