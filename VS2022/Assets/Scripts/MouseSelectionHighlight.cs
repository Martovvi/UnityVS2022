using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelectionHighlight : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial = null;

    private Material defaultMaterial;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    private void OnMouseEnter()
    {
        meshRenderer.material = highlightMaterial;
    }

    private void OnMouseExit()
    {
        meshRenderer.material = defaultMaterial;
    }
}
