using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog {
    public Talker _talker;

    [UnityEngine.TextArea]
    public string[] messages;
}
