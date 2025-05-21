using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint basicTurret;
    public TurretBlueprint strongerTurret;
    public TurretBlueprint strongTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBasicTurret() { buildManager.SelectTurretToBuild(basicTurret); }
    public void SelectStrongerTurret() { buildManager.SelectTurretToBuild(strongerTurret); }
    public void SelectStrongeTurret() { buildManager.SelectTurretToBuild(strongTurret); }
}
