using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour, IInteractionListener
{
    // ToDo: Add Invoke actions
    [SerializeField] private InteractionUI ui;
    [SerializeField] private List<Interaction> interactions;
    [SerializeField] private UnityEvent OnCompleted;

    public bool InteractionsCompleted => interactionIndex >= interactions.Count;
    private int interactionIndex;
    private Interaction currentInteraction;
    private bool interactionInProgress;
    private int errorCount;
    private int helpCount;

    private void Start()
    {
        if (interactions.Count == 0)
        {
            Debug.LogWarning("No Interactions in Interaction Manager.");
            return;
        }

        currentInteraction = interactions[interactionIndex];
        ui.DisplayInstruction(currentInteraction.Instruction);
    }

    private void Update()
    {
        // Users can request help with the H key as long as we still have "open" interactions (the training is not completed).
        if (Input.GetKeyDown(KeyCode.H) && !InteractionsCompleted)
        {
            helpCount++;
            ui.DisplayHelp(currentInteraction.HelpMsg, helpCount);
        }
    }

    private void OnEnable()
    {
        var globalInteractables = FindObjectsOfType<Interactable>(true);

        foreach (var interactable in globalInteractables)
        {
            Debug.Log(interactable.name);
            interactable.AddListener(this);
        }
    }

    private void OnDisable()
    {
        var globalInteractables = FindObjectsOfType<Interactable>(true);

        foreach (var interactable in globalInteractables)
        {
            interactable.RemoveListener(this);
        }
    }

    public void OnNotify(Interactable interactable)
    {
        if (interactionInProgress)
            return;

        if (InteractionsCompleted)
            return;

        if (interactable.Equals(currentInteraction.Interactable))
        {
            StartCoroutine(UpdateInteraction());
        }
        else
        {
            ui.DisplayError(currentInteraction.ErrorMsg, ++errorCount);
        }
    }

    private IEnumerator UpdateInteraction()
    {
        interactionInProgress = true;
        ui.StopHelpAndErrorDisplay();
        currentInteraction.OnStart?.Invoke();
        yield return new WaitForSeconds(currentInteraction.Duration);
        currentInteraction.OnEnd?.Invoke();
        interactionIndex++;

        if (interactionIndex < interactions.Count)
        {
            currentInteraction = interactions[interactionIndex];
            ui.DisplayInstruction(currentInteraction.Instruction);
        }
        else
        {
            OnCompleted?.Invoke();
        }

        // At the end we unlock the Interaction Manager to process interactions again.
        interactionInProgress = false;
    }
}

