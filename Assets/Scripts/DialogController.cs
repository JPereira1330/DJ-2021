using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour {

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

    private GameObject[] player_01;
    private GameObject[] player_02;

    void Start(){

        objTerra    = GameObject.FindGameObjectWithTag("OBJ_TERRA");
        objMarte    = GameObject.FindGameObjectWithTag("OBJ_MARTE");
        objTerraOld = GameObject.FindGameObjectWithTag("OBJ_TERRA_OLD");
        objDescri   = GameObject.FindGameObjectWithTag("DIALOG_MSG");
        objTitulo   = GameObject.FindGameObjectWithTag("DIALOG_TITULO");
        objBoxDia   = GameObject.FindGameObjectWithTag("DIALOG_BOX");
        objPlanDg   = GameObject.FindGameObjectWithTag("DIALOG_PLANETA");

        player_01 = GameObject.FindGameObjectsWithTag("PERSO_01");
        player_02 = GameObject.FindGameObjectsWithTag("PERSO_02");

        txtDesc = objDescri.GetComponent<Text>();
        txtTitulo = objTitulo.GetComponent<Text>();
        txtPlaneta = objPlanDg.GetComponent<Text>();

        index = 0;
        audioCtrl = GetComponent<AudioSource>();

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

    void Update(){

        if ( Input.GetKeyDown(KeyCode.Space) ) {
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

    void setDialog(string  personagem, string dialogo) {

        if (personagem == "Programador") {
            objBoxDia.SetActive(true);
            player_01[0].SetActive(true);
            player_01[1].SetActive(true);
            player_02[0].SetActive(false);
            player_02[1].SetActive(false);
        } else if(personagem == "Estagiario") {
            objBoxDia.SetActive(true);
            player_01[0].SetActive(false);
            player_01[1].SetActive(false);
            player_02[0].SetActive(true);
            player_02[1].SetActive(true);
        } else {
            objBoxDia.SetActive(false);
            player_01[0].SetActive(false);
            player_01[1].SetActive(false);
            player_02[0].SetActive(false);
            player_02[1].SetActive(false);
        }

        txtTitulo.text = personagem;
        txtDesc.text = dialogo;
    
    }

    void writeHistoriaIntro(int index) {

        int terra = 1;
        int marte = 2;
        int terra_old = 3;

        string pers01 = "Programador";
        string pers02 = "Estagiario";

        switch (index) {

            case 0:
                desaparecePlaneta(terra);
                setDialog(pers01, "O que aconteceu aqui? Onde esta a Terra?");
                break;
            case 1:
                setDialog(pers02, "Desculpa!!!, fui ligar a cafeteira e puxei o cabo errado");
                break;
            case 2:
                setDialog(pers01, "E por que o servidor da terra ainda não esta ligado??");
                break;
            case 3:
                setDialog(pers02, "Então...");
                break;
            case 4:
                setDialog(pers02, "O servidor da terra não esta ligando, aparece um 'bad block', não sei o que é.");
                break;
            case 5:
                setDialog(pers01, "E o Backup?");
                break;
            case 6:
                setDialog(pers02, "...");
                break;
            case 7:
                setDialog(pers01, "E??? Prossiga!");
                break;
            case 8:
                setDialog(pers02, "O ultimo backup foi feito a 300 mil anos atras!");
                break;
            case 9:
                setDialog(pers01, "... O que?");
                break;
            case 10:
                setDialog(pers01, "Vocês só me decpcionam, pela sétima vez que perdemos os dados da terra.");
                break;
            case 11:
                setDialog(pers02, "Posso subir o backup da terra para o servidor?");
                break;
            case 12:
                setDialog(pers01, "... Deve! Me avise quando estiver de volta");
                break;
            case 13:
                exibePlaneta(marte);
                setDialog("", "");
                break;
            case 14:
                setDialog(pers02, "Ops, Dimensão errada.");
                break;
            case 15:
                desaparecePlaneta(marte);
                exibePlaneta (terra_old);
                setDialog(pers02, "Agora sim!");
                break;
            case 16:
                setDialog(pers02, "Programador, terminei!");
                break;
            case 17:
                setDialog(pers01, "Blz, Agora tenho trabalho para seis dias, ao menos poderei descançar no setimo.");
                break;
            case 18:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }

    }

}
