using System;
using UnityEngine.Events;

[Serializable]
    public class Interaction
    {
        public Interactable Interactable;
        public string Instruction;
        public string HelpMsg;
        public string ErrorMsg;
        public float Duration;
        public UnityEvent OnStart;
        public UnityEvent OnEnd;
        public bool HelpCounted { get; set; }
    }

