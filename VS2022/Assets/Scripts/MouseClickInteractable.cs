using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickInteractable : Interactable
{
    private void OnMouseDown() => Notify();
}
