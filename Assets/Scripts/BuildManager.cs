using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public bool isRemoving = false;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public void EnableRemoveMode()
    {
        isRemoving = true;
    }

    public void EnableBuildMode()
    {
        isRemoving = false;
    }

    private TurretBlueprint turretToBuild;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        isRemoving = false; // exit remove mode when selecting a turret
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
