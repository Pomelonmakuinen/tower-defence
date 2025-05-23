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
        if (Time.timeScale == 0f)
            return;

        if (BuildManager.instance.isRemoving)
        {
            if (sprinkler == null)
            {
                Debug.Log("No turret to remove.");
                return;
            }

            PlayerStats.Money += 10;
            Destroy(sprinkler);
            SFXManager.Instance.PlayRemoveSound();
            sprinkler = null;
            Debug.Log("Turret removed.");
            return;
        }

        if (sprinkler != null)
        {
            Debug.Log("Can't build here.");
            return;
        }

        TurretBlueprint blueprint = BuildManager.instance.GetTurretToBuild();
        if (blueprint == null || PlayerStats.Money < blueprint.cost)
            return;

        PlayerStats.Money -= blueprint.cost;
        sprinkler = Instantiate(blueprint.prefab, transform.position, transform.rotation);

        Sprinkler sprinklerScript = sprinkler.GetComponent<Sprinkler>();
        if (sprinklerScript != null)
        {
            sprinklerScript.damage = blueprint.damage;
        }

        // Play turret placement sound
        SFXManager.Instance.PlayTurretPlace();
    }


    void OnMouseEnter()
    {
        if (Time.timeScale == 0f)
            return;

        if (PauseMenu.GameIsPaused) return;  // Prevent highlight while paused
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (PauseMenu.GameIsPaused) return;  // Prevent color reset if paused
        rend.material.color = startColor;
    }
}
