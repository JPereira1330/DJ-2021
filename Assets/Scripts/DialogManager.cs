using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour { 

    public static DialogManager Instance;

    public static event System.Action<Dialog> NewTalker;
    public static event System.Action ResetText;
    public static event System.Action<string> ShowMessage;
    public static event System.Action<bool> UIState;

    private DialogContainer currentDialog;

    private bool endCurrentTalk = true;
    private bool buttonClicked = false;

    void Awake() {
        Instance = this;
    }

    public void StartConversation(DialogContainer container) {
        currentDialog = container;
        StartCoroutine(StartDialog());
        UIState?.Invoke(true);
    }

    private IEnumerator StartDialog() {
        for(int i = 0; i < currentDialog._dialogs.Length; i++) {
            ResetText?.Invoke();
            NewTalker?.Invoke(currentDialog._dialogs[i]);
            StartCoroutine(ShowDialog(currentDialog._dialogs[i].messages));
            
            yield return new WaitUntil(() => endCurrentTalk);
        }
        UIState?.Invoke(false);
    }

    private IEnumerator ShowDialog(string[] messages) {
        endCurrentTalk = false;

        foreach(var message in messages) {
            ShowAllMessage(message);
            yield return new WaitUntil(() => buttonClicked);
        }

        endCurrentTalk = true;
    }

    private void ShowAllMessage(string message) {
        ShowMessage?.Invoke(message);
        buttonClicked = false;
    }

    public void ButtonWasClicked() {
        buttonClicked = true;
    }

}
