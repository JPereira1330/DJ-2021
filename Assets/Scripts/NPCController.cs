using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour{

	[SerializeField] Dialog dialog;

    public void Interact(){
    	DialogoScript.Instance.ShowDialog(dialog);
    }

    void Start() {
        Interact();
    }
}
