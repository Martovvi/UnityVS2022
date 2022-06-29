using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ObjectDisappear : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisappear;

    public void MakeObjectDisappear()
    {
        objectToDisappear.SetActive(false);
    }
}
