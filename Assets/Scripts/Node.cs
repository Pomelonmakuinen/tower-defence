using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject sprinkler;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (sprinkler != null)
        {
            Debug.Log("Can't build there :-D");
            return;
        }

        // Block building while paused
        if (Time.timeScale == 0f)
            return;

        TurretBlueprint blueprint = BuildManager.instance.GetTurretToBuild();

        if (blueprint == null || PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money or turret not selected.");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        sprinkler = Instantiate(blueprint.prefab, transform.position, transform.rotation);
    }



    void OnMouseEnter()
    {
        if (PauseMenu.GameIsPaused) return;  // Prevent highlight while paused
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (PauseMenu.GameIsPaused) return;  // Prevent color reset if paused
        rend.material.color = startColor;
    }
}
