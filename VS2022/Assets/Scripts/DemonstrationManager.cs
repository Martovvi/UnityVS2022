using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DemonstrationManager : MonoBehaviour
{
    [SerializeField] private DemonstrationUI ui;
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
            Debug.LogWarning("No Demonstrations in Demonstration Manager.");
            return;
        }

        currentDemonstration = demonstrations[demonstrationIndex];
        ui.DisplayInstruction(currentDemonstration.Instruction);
        nextButton.onClick.AddListener(gotToNextStep);
        prevButton.onClick.AddListener(gotToPrevStep);
        StartCoroutine(UpdateDemonstration(demonstrationIndex));
    }

    void gotToNextStep()
        {
            // StopAllCoroutines();
            demonstrationIndex++;
            StartCoroutine(UpdateDemonstration(demonstrationIndex));
        }

    void gotToPrevStep()
        {
            // StopAllCoroutines();
            demonstrationIndex--;
            StartCoroutine(UpdateDemonstration(demonstrationIndex));
        }      

    private IEnumerator UpdateDemonstration(int demonstrationIndex)
    {
        if (demonstrationIndex == 0)
        {
            prevButton.enabled = false;
        }
        else
        {
            prevButton.enabled = true;
        }
           
        if (demonstrationIndex < demonstrations.Count)
        {
            nextButton.enabled = true;
            currentDemonstration = demonstrations[demonstrationIndex];
            currentDemonstration.OnStart?.Invoke();
            yield return new WaitForSeconds(0);
            currentDemonstration.OnEnd?.Invoke(); 
            ui.DisplayInstruction(currentDemonstration.Instruction);
        }
        else
        {
            nextButton.enabled = false;
            OnCompleted?.Invoke();
        }
    }
}
