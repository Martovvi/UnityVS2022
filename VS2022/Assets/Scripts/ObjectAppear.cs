using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ObjectAppear : MonoBehaviour
{
    [SerializeField] private GameObject objectToAppear;

    public void MakeObjectAppear()
    {
        objectToAppear.SetActive(true);
    }
}
