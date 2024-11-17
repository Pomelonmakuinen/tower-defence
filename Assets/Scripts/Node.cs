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
            Debug.Log("cant build there :-D");
            return;
        }

        GameObject sprinklerToBuild = BuildManager.instance.GetSprinklerToBuild();
        sprinkler = (GameObject)Instantiate(sprinklerToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
