using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private List<IInteractionListener> listeners = new List<IInteractionListener>();

    public void AddListener(IInteractionListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void RemoveListener(IInteractionListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

    public void Notify()
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnNotify(this);
    }
}
