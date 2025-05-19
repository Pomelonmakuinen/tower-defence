using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager :-D");
            return;
        }

        instance = this;
    }

    public TurretBlueprint standardSprinkler;

    public TurretBlueprint GetTurretToBuild()
    {
        return standardSprinkler;
    }
}
