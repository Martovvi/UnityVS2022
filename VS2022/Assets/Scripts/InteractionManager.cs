using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour, IInteractionListener
{
    [SerializeField] private InteractionUI ui;
    [SerializeField] private Button helpButton;
    [SerializeField] private List<Interaction> interactions;
    [SerializeField] private UnityEvent OnCompleted;
    [SerializeField] private AudioSource wrongSound;
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource notificationSound;

    public bool InteractionsCompleted => interactionIndex >= interactions.Count;
    private int interactionIndex;
    private Interaction currentInteraction;
    private bool interactionInProgress;
    private int errorCount;
    private int helpCount;
    private int interactionStepError = -1;
    private int interactionStepHelp = -1;
    private int stepCount;
    

    private void Start()
    {
        if (interactions.Count == 0)
        {
            Debug.LogWarning("No Interactions in Interaction Manager.");
            return;
        }

        currentInteraction = interactions[interactionIndex];
        stepCount = interactions.Count;
        ui.DisplayInstruction("Schritt " + (interactionIndex + 1) + " / " + stepCount + " " + currentInteraction.Instruction);
        helpButton.onClick.AddListener(showHelpMsg);
    }

     void showHelpMsg()
        {
            if (!InteractionsCompleted)
            {
               if(interactionIndex != interactionStepHelp)
               {
                  helpCount++;
                  interactionStepHelp = interactionIndex;
               }
               ui.DisplayHelp(currentInteraction.HelpMsg, helpCount);
               notificationSound.Play();
            }
        }    

    private void OnEnable()
    {
        var globalInteractables = FindObjectsOfType<Interactable>(true);

        foreach (var interactable in globalInteractables)
        {
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
            if (interactionIndex != interactionStepError)
            {
                wrongSound.Play();
                ui.DisplayError(currentInteraction.ErrorMsg, ++errorCount);
                interactionStepError = interactionIndex;
            }
        }
    }

    private IEnumerator UpdateInteraction()
    {
        correctSound.Play();
        interactionInProgress = true;
        ui.StopHelpAndErrorDisplay();
        currentInteraction.OnStart?.Invoke();
        yield return new WaitForSeconds(currentInteraction.Duration);
        currentInteraction.OnEnd?.Invoke();
        interactionIndex++;

        if (interactionIndex < interactions.Count)
        {
            currentInteraction = interactions[interactionIndex];
            // ToDo
            ui.DisplayInstruction("Schritt " + (interactionIndex + 1) + " / " + stepCount + " " + currentInteraction.Instruction);
        }
        else
        {
            OnCompleted?.Invoke();
        }

        // At the end we unlock the Interaction Manager to process interactions again.
        interactionInProgress = false;
    }
}

