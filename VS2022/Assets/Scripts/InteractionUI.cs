using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionLabel;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private TextMeshProUGUI resultLabel;
    [SerializeField] private TextMeshProUGUI ratingLabel;
    [SerializeField] private GameObject helpBox;

    [SerializeField] private TextMeshProUGUI errorCountLabel = null;
    [SerializeField] private TextMeshProUGUI helpCountLabel = null;
    [SerializeField] private float helpDisplayTime = 5.0f;
    [SerializeField] private float errorDisplayTime = 5.0f;

    private void Awake()
    {
        instructionLabel.SetText("");
        errorLabel.SetText("");
        helpLabel.SetText("");
        helpCountLabel.SetText("0");
        errorCountLabel.SetText("0");
    }


    public void DisplayInstruction(string instruction)
    {
        StopDisplays();
        instructionLabel.SetText(instruction);
    }

    public void DisplayHelp(string helpMsg, int helpCount)
    {
        StopDisplays();
        helpCountLabel.text = helpCount + "";
        helpBox.SetActive(true);
        StartCoroutine(DisplayForDuration(helpLabel, helpMsg, helpDisplayTime));
    }

    public void DisplayError(string errorMsg, int errorCount)
    {
        StopDisplays();
        errorCountLabel.text = errorCount + "";
        StartCoroutine(DisplayForDuration(errorLabel, errorMsg, errorDisplayTime));
    }

    public void DisplayResult(string result)
    {
        StopDisplays();
        resultLabel.SetText(result);
    }

    public void DisplayRating(string rating)
    {
        StopDisplays();
        ratingLabel.SetText(rating);
    }

    public void StopDisplays()
    {
        StopAllCoroutines();
        helpLabel.SetText("");
        errorLabel.SetText("");
        helpBox.SetActive(false);
    }

    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
    {
        label.text = msg;
        yield return new WaitForSeconds(duration);
        label.text = "";
        helpBox.SetActive(false);
    }
}

