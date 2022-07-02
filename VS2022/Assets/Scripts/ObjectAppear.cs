using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ObjectAppear : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectToAppear;

    public void MakeObjectAppear(int index)
    {
        objectToAppear[index].SetActive(true);
    }
}
