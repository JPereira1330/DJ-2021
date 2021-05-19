using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{

    Vector3 rotationEulerTerra;
    private GameObject[] objsTerra;

    private GameObject menu01;
    private GameObject menu02;

    void Start(){

        objsTerra   = GameObject.FindGameObjectsWithTag("OBJ_TERRA");
        menu01      = GameObject.FindGameObjectWithTag("MENU_INICIAR");
        menu02      = GameObject.FindGameObjectWithTag("MENU_OPTIONS");

        rotationEulerTerra = Vector3.forward * 5 * Time.deltaTime; //increment 30 degrees every second
        objsTerra[0].transform.rotation = Quaternion.Euler(rotationEulerTerra);
        objsTerra[1].transform.rotation = Quaternion.Euler(rotationEulerTerra * 2);

        menu01.SetActive(true);
        menu02.SetActive(false);

    }

    void Update(){
        rotationEulerTerra += Vector3.forward * 10 * Time.deltaTime; //increment 30 degrees every secon
        objsTerra[0].transform.rotation = Quaternion.Euler(rotationEulerTerra);
        objsTerra[1].transform.rotation = Quaternion.Euler(rotationEulerTerra * 2);
    }

    public void IniciaGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TrocaInterface() {
        menu01.SetActive( ! menu01.activeSelf );
        menu02.SetActive( ! menu02.activeSelf );
    }

    public void sairdoJogo() {
        Application.Quit();
    }

}
