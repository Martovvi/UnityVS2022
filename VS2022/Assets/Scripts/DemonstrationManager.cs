using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DemonstrationManager : MonoBehaviour
{
    [SerializeField] private InteractionUI ui;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private List<Demonstration> demonstrations;
    [SerializeField] private UnityEvent OnCompleted;

    public bool DemonstartionsCompleted => demonstrationIndex >= demonstrations.Count;
    private int demonstrationIndex;
    private Demonstration currentDemonstration;
    private int stepCount;
    

    private void Start()
    {
        if (demonstrations.Count == 0)
        {
            Debug.LogWarning("No Demonstrations in Interaction Manager.");
            return;
        }

        currentDemonstration = demonstrations[demonstrationIndex];
        stepCount = demonstrations.Count;
        ui.DisplayInstruction(currentDemonstration.Instruction);
        nextButton.onClick.AddListener(gotToNextStep);
        prevButton.onClick.AddListener(gotToPrevStep);
    }

    void gotToNextStep()
        {
           StartCoroutine(UpdateDemonstration());
        }

    void gotToPrevStep()
        {
           demonstrationIndex--;
        }      

    // public void OnNotify(Interactable interactable)
    // {

    //     if (DemonstartionsCompleted)
    //         return;

    //     StartCoroutine(UpdateDemonstration());
    // }
    

    private IEnumerator UpdateDemonstration()
    {
        ui.StopDisplays(); 
        currentDemonstration.OnStart?.Invoke();
        yield return new WaitForSeconds(0);
        currentDemonstration.OnEnd?.Invoke();
        demonstrationIndex++;      

        if (demonstrationIndex < demonstrations.Count)
        {
            currentDemonstration = demonstrations[demonstrationIndex];
            ui.DisplayInstruction(currentDemonstration.Instruction);
        }
        else
        {
            OnCompleted?.Invoke();
        }
    }
}
