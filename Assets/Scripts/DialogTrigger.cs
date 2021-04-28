using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
    public DialogContainer dialogContainer;

    void Start()
    {
        DialogManager.Instance.StartConversation(dialogContainer);
    }

}
