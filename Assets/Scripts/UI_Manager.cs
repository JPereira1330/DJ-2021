using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
    public GameObject UIContainer;
    public Image _image;
    public Text _talkerName;
    public Text _dialog;

    void Awake() {
        DialogManager.NewTalker += NewTalker;
        DialogManager.ShowMessage += ShowText;
        DialogManager.ResetText += ResetText;
        DialogManager.UIState += UIContainerState;
    }

    void OnDestroy() {
        DialogManager.NewTalker -= NewTalker;
        DialogManager.ShowMessage -= ShowText;
        DialogManager.ResetText -= ResetText;
        DialogManager.UIState -= UIContainerState;
    }

    private void NewTalker(Dialog talkerInformations) {
        _image.sprite = talkerInformations._talker._sprite;
        _talkerName.text = talkerInformations._talker.name;
        //_image.GetComponent<Animator>().SetTrigger("animation");
    }

    private void ShowText(string message) =>
        _dialog.text = message;

    private void ResetText() =>
        _dialog.text = string.Empty;

    private void UIContainerState(bool state) =>
        UIContainer.SetActive(state);

    
}
