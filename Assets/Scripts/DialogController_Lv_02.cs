using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class DialogController_Lv_02 : MonoBehaviour { 
    
    private int index;
    Vector3 rotationEulerTerra;

    private Text txtDesc;
    private Text txtTitulo;
    private Text txtPlaneta;

    private GameObject objMarte;
    private GameObject objTerra;
    private GameObject objTerraOld;
    private GameObject objTitulo;
    private GameObject objDescri;
    private GameObject objBoxDia;
    private GameObject objPlanDg;
    private AudioSource audioCtrl;
    private AudioSource audioBleep;

    private GameObject[] player_01;
    private GameObject[] player_02;

    void Start() {

        objTerra = GameObject.FindGameObjectWithTag("OBJ_TERRA");
        objMarte = GameObject.FindGameObjectWithTag("OBJ_MARTE");
        objTerraOld = GameObject.FindGameObjectWithTag("OBJ_TERRA_OLD");
        objDescri = GameObject.FindGameObjectWithTag("DIALOG_MSG");
        objTitulo = GameObject.FindGameObjectWithTag("DIALOG_TITULO");
        objBoxDia = GameObject.FindGameObjectWithTag("DIALOG_BOX");
        objPlanDg = GameObject.FindGameObjectWithTag("DIALOG_PLANETA");

        player_01 = GameObject.FindGameObjectsWithTag("PERSO_01");
        player_02 = GameObject.FindGameObjectsWithTag("PERSO_02");

        txtDesc = objDescri.GetComponent<Text>();
        txtTitulo = objTitulo.GetComponent<Text>();
        txtPlaneta = objPlanDg.GetComponent<Text>();

        index = 0;
        audioCtrl = GetComponent<AudioSource>();
        audioBleep = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();

        objBoxDia.SetActive(false);
        player_01[0].SetActive(false);
        player_01[1].SetActive(false);
        player_02[0].SetActive(false);
        player_02[1].SetActive(false);
        objMarte.SetActive(false);
        objTerraOld.SetActive(false);

        txtPlaneta.text = "Terra";

        rotationEulerTerra = Vector3.forward * 10 * Time.deltaTime; //increment 10 degrees every second
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            writeHistoriaIntro(index);
            index++;
        }

        if (objTerra.activeSelf == true) {
            rotationEulerTerra += Vector3.forward * 10 * Time.deltaTime; //increment 30 degrees every second
            objTerra.transform.rotation = Quaternion.Euler(rotationEulerTerra);
        }

        if (objTerraOld.activeSelf == true) {
            rotationEulerTerra += Vector3.forward * 10 * Time.deltaTime; //increment 30 degrees every second
            objTerraOld.transform.rotation = Quaternion.Euler(rotationEulerTerra);
        }

    }
    void desaparecePlaneta(int id) {

        audioCtrl.Play();

        switch (id) {

            case 1: // Planeta Terra
                objTerra.SetActive(false);
                txtPlaneta.text = " ? ? ? ";
                break;

            case 2: // Planeta Marte
                objMarte.SetActive(false);
                txtPlaneta.text = "Marte";
                break;

            case 3: // Planeta Terra Velha
                objTerraOld.SetActive(false);
                txtPlaneta.text = "Terra";
                break;
        }
    }

    void exibePlaneta(int id) {

        audioCtrl.Play();

        switch (id) {

            case 1: // Planeta Terra
                objTerra.SetActive(true);
                txtPlaneta.text = "Terra";
                break;

            case 2: // Planeta Marte
                objMarte.SetActive(true);
                txtPlaneta.text = "Dimensão 35-C | Terra";
                break;

            case 3: // Planeta Terra Velha
                objTerraOld.SetActive(true);
                txtPlaneta.text = "Terra";
                break;
        }

    }
    async void setDialog(string personagem, string dialogo) {

        if (personagem == "Programador") {
            objBoxDia.SetActive(true);
            player_01[0].SetActive(true);
            player_01[1].SetActive(true);
            player_02[0].SetActive(false);
            player_02[1].SetActive(false);
        }
        else if (personagem == "Estagiario") {
            objBoxDia.SetActive(true);
            player_01[0].SetActive(false);
            player_01[1].SetActive(false);
            player_02[0].SetActive(true);
            player_02[1].SetActive(true);
        }
        else {
            objBoxDia.SetActive(false);
            player_01[0].SetActive(false);
            player_01[1].SetActive(false);
            player_02[0].SetActive(false);
            player_02[1].SetActive(false);
        }

        txtTitulo.text = personagem;

        txtDesc.text = "";
        for (int cont = 0; cont < dialogo.Length; cont++) {
            txtDesc.text += dialogo[cont];
            audioBleep.Play();
            await Task.Delay(90);
        }

    }

    void writeHistoriaIntro(int index) {

        int terra = 1;
        int marte = 2;
        int terra_old = 3;

        string pers01 = "Programador";
        string pers02 = "Estagiario";

        switch (index) {

            case 0:
                exibePlaneta(terra);
                desaparecePlaneta(marte);
                desaparecePlaneta(terra_old);
                setDialog(pers01, "Agora sim, mais apresentavel!");
                break;
            case 1:
                setDialog(pers02, "Nossa, mas já terminou?");
                break;
            case 2:
                setDialog(pers01, "Ainda não, Acabei de terminar a criação do planeta");
                break;
            case 3:
                setDialog(pers01, "Agora tenho que realizar a transformação planetaria!");
                break;
            case 4:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }

    }

}
