using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI selectionLabel;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject[] objectsInOrder;
    private int objectIndex;
    private Camera cam;
    private GameObject mouseOverGameObject;

    private void Awake() => cam = Camera.main;

    void Start()
    {
        selectionLabel.text = "";
    }

    void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 100, layerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);

            if (!mouseOverGameObject)
            {
                mouseOverGameObject = hit.collider.gameObject;
            }
            else if (!mouseOverGameObject.Equals(hit.transform.gameObject))
            {
                mouseOverGameObject = null;
            }
        }
        else if (mouseOverGameObject)
        {
            mouseOverGameObject = null;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * 20, Color.red);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (objectIndex >= objectsInOrder.Length)
                return;

            if (!mouseOverGameObject)
                return;

            if (mouseOverGameObject.Equals(objectsInOrder[objectIndex]))
            {
                objectIndex++;
                selectionLabel.text = "Nr. " + objectIndex + " " + mouseOverGameObject.name;
            }
            else
            {
                selectionLabel.text = "Wrong Order";
            }
        }
    }
}
