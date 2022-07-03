using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DemonstrationUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionLabel;

    private void Awake()
    {
        instructionLabel.SetText("");
    }


    public void DisplayInstruction(string instruction)
    {
        instructionLabel.SetText(instruction);
    }
}
