using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppearTemporary : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowForXSeconds());
    }

    IEnumerator ShowForXSeconds()
    {
        yield return new WaitForSeconds(time);
        item.SetActive(false);
    }
}
