using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Material wallMaterial;
    public Color currentColor;
    private void Start()
    {
        
        currentColor = wallMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            wallMaterial.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wallMaterial.color = currentColor;
    }
}
