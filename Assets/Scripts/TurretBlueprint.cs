using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public GameObject previewPrefab;
    public int cost;
    private TurretBlueprint turretToBuild;
    public float damage;
    public static BuildManager instance;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
