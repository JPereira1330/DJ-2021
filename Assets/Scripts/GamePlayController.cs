using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class GamePlayController : MonoBehaviour {

    public int capitulo;
    Vector3 rotationEulerTerra;
    private int quantiaElementosSalvo;

    private string strSlotCraft01;
    private string strSlotCraft02;
    public Sprite btnOK;
    public Sprite btnCancel;

    private GameObject planetaTerra;
    private GameObject levelController;
    private GameObject[] slotCraft01;
    private GameObject[] slotCraft02;
    private GameObject[] listElementos;
    private GameObject[] listPendencias;
    
    public Sprite iconElementosAgua;
    public Sprite iconElementosFogo;
    public Sprite iconElementosTerra;
    public Sprite iconElementosPedra;
    public Sprite iconElementosLava;
    public Sprite iconElementosVulcao;
    public Sprite iconElementosMar;
    public Sprite iconElementosIlha;
    public Sprite iconElementosArquipelago;
    public Sprite iconElementosContinente;

    void Start(){

        // Inicializacoes objetos
        planetaTerra = GameObject.FindGameObjectWithTag("OBJ_TERRA");
        slotCraft01 = GameObject.FindGameObjectsWithTag("CRAFT_SLOT_01");
        slotCraft02 = GameObject.FindGameObjectsWithTag("CRAFT_SLOT_02");
        listElementos = GameObject.FindGameObjectsWithTag("ELEMENTO");
        listPendencias = GameObject.FindGameObjectsWithTag("LIST_PENDENCIA");
        levelController = GameObject.FindGameObjectWithTag("Finish");

        // Inicializando valores
        capitulo = 1;
        quantiaElementosSalvo = 0;
        slotCraft01[1].SetActive(false);
        slotCraft02[1].SetActive(false);
        levelController.SetActive(false);

        // Iniciando valores da array de pendecias
        for (int cont = 0; listPendencias.Length > cont; cont++) {
            listPendencias[cont].GetComponent<Text>().color = Color.clear;
        }

        // Inicializando animacoes
        rotationEulerTerra = Vector3.forward * 10 * Time.deltaTime; //increment 10 degrees every second
        
        initCapitulo(capitulo);
    }

    // Update is called once per frame
    void Update(){

        // Animações da tela
        playAnimation();
        verificaCapitulo();

    }

    void playAnimation() {

        // Planeta terra girando
        if (planetaTerra.activeSelf == true) {
            rotationEulerTerra += Vector3.forward * 10 * Time.deltaTime; //increment 30 degrees every second
            planetaTerra.transform.rotation = Quaternion.Euler(rotationEulerTerra);
        }

        // Box Slot 01
        if (slotCraft01[1].activeSelf) { slotCraft01[0].GetComponent<Image>().sprite = btnOK; }
        else { slotCraft01[0].GetComponent<Image>().sprite = btnCancel; }

        // Box Slot 02
        if (slotCraft02[1].activeSelf) { slotCraft02[0].GetComponent<Image>().sprite = btnOK; }
        else { slotCraft02[0].GetComponent<Image>().sprite = btnCancel; }
    }

    void initCapitulo(int capitulo) {

        quantiaElementosSalvo = 0;
        slotCraft01[1].SetActive(false);
        slotCraft02[1].SetActive(false);

        switch (capitulo) {
            case 1:
                initCapitulo01();
                break;
            case 2:
                initCapitulo02();
                break;
        }
    }

    void initCapitulo01() {

        string[] capitulo01 = new string[4];
        capitulo01[0] = "ELEMENTO_AGUA";
        capitulo01[1] = "ELEMENTO_FOGO";
        capitulo01[2] = "ELEMENTO_TERRA";
        capitulo01[3] = "ELEMENTO_PEDRA";

        for (int cont = 0; listPendencias.Length > cont; cont++) {
            listPendencias[cont].GetComponent<Text>().color = Color.red;
        }

        addElements(capitulo01);
    }

    async void initCapitulo02() {

        Animator animacao;
        string[] capitulo02 = new string[4];

        // Realizando animação de troca
        levelController.SetActive(true);
        animacao = levelController.GetComponent<Animator>();
        animacao.SetTrigger("FadeOut");

        await Task.Delay(1500);

        // Elemento inicicias
        capitulo02[0] = "ELEMENTO_AGUA";
        capitulo02[1] = "ELEMENTO_FOGO";
        capitulo02[2] = "ELEMENTO_TERRA";
        capitulo02[3] = "ELEMENTO_LAVA";
        addElements(capitulo02);

        // Reorganizando Lista de pendencias
        for (int cont = 0; listPendencias.Length > cont; cont++) {
            listPendencias[cont].GetComponent<Text>().color = Color.red;
            listPendencias[cont].GetComponent<Text>().text = "";
        }

        listPendencias[0].GetComponent<Text>().text = "BACTERIA";
        listPendencias[1].GetComponent<Text>().text = "VAPOR";
        listPendencias[2].GetComponent<Text>().text = "LAMA";
        listPendencias[3].GetComponent<Text>().text = "MATERIA ORGANICA";
        listPendencias[4].GetComponent<Text>().text = "OZONIO";

        // Alterando variaveis
        GameObject.FindGameObjectWithTag("TLT_GP_ANO").GetComponent<Text>().text = "teste";
        GameObject.FindGameObjectWithTag("TLT_GP_CAP").GetComponent<Text>().text = "TERRA - Capitulo 02";
    }

    void verificaCapitulo() {

        int cont;
        int resultado = 0;

        for(cont = 0; cont < listPendencias.Length; cont++) {
            if (listPendencias[cont].GetComponent<Text>().color == Color.green) {
                resultado++;
            }else if (listPendencias[cont].GetComponent<Text>().text == "") {
                resultado++;
            }
        }

        if (resultado >= (listPendencias.Length)) {
            capitulo++;
            initCapitulo(capitulo);
        }

    }

    void addElements(string[] tags) {

        int index;
        string titulo;
        Sprite img;

        titulo = "";
        img = null;

        for (index = 0; index < tags.Length; index++) {

            switch (tags[index]) {

                case "ELEMENTO_AGUA":
                    titulo = "AGUA";
                    img = iconElementosAgua;
                    break;

                case "ELEMENTO_FOGO":
                    titulo = "FOGO";
                    img = iconElementosFogo;
                    break;

                case "ELEMENTO_PEDRA":
                    titulo = "PEDRA";
                    img = iconElementosPedra;
                    break;

                case "ELEMENTO_TERRA":
                    titulo = "TERRA";
                    img = iconElementosTerra;
                    break;

                case "ELEMENTO_LAVA":
                    titulo = "LAVA";
                    img = iconElementosLava;
                    break;

                case "ELEMENTO_VULCAO":
                    titulo = "VULCAO";
                    img = iconElementosVulcao;
                    break;

                case "ELEMENTO_MAR":
                    titulo = "MAR";
                    img = iconElementosMar;
                    break;

                case "ELEMENTO_ILHA":
                    titulo = "ILHA";
                    img = iconElementosIlha;
                    break;

                case "ELEMENTO_ARQUIPELAGO":
                    titulo = "ARQUIPELAGO";
                    img = iconElementosArquipelago;
                    break;

                case "ELEMENTO_CONTINENTE":
                    titulo = "CONTINENTE";
                    img = iconElementosContinente;
                    break;
            }

            addElementoOnTable(index, tags[index], titulo, img);
        }

        // Limpando a tela
        for(;index < listElementos.Length; index++) {
            listElementos[index].SetActive(false);
        }

    }

    void addElementoOnTable(int index, string tag, string titulo, Sprite img) {
        
        if (verificaSeCraftado(tag)) {
            return;
        }

        listElementos[index].SetActive(true);
        listElementos[index].tag = tag;
        listElementos[index].GetComponent<Image>().sprite = img;
        listElementos[index].GetComponent<Button>().onClick.AddListener(delegate { addToCraft(titulo, img); });
        listElementos[index].GetComponentInChildren<Text>().text = titulo;
        
        quantiaElementosSalvo++;
    }

    void addToCraft(string tag, Sprite img) {

        if ( slotCraft01[1].activeSelf == false ) {
            slotCraft01[1].GetComponent<Image>().sprite = img;
            strSlotCraft01 = tag;
            slotCraft01[1].SetActive(true);
            return;
        }

        if ( slotCraft02[1].activeSelf == false ) {
            slotCraft02[1].GetComponent<Image>().sprite = img;
            strSlotCraft02 = tag;
            slotCraft02[1].SetActive(true);
            return;
        }

    }
    bool verificaSeCraftado(string tag) {

        int i;

        for(i=0; i < listElementos.Length; i++) {
            if (listElementos[i].tag == tag) {
                return true;
            }
        }

        return false;
    }

    bool toAuxCraft(string craft01, string craft02) {

        // N crafta caso algum deles desativado
        if ( slotCraft01[1].activeSelf == false || slotCraft02[1].activeSelf == false) {
            return false;
        }

        if (strSlotCraft01.Equals(craft01) && strSlotCraft02.Equals(craft02)) {
            return true;
        } else if (strSlotCraft01.Equals(craft02) && strSlotCraft02.Equals(craft01)) {
            return true;
        }

        return false;
    }

    public void toCraft() {

        // Craftando Mar
        if (toAuxCraft("AGUA", "AGUA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_MAR", "MAR", iconElementosMar);
            setFinishPendencia("MAR", true);
        }

        // Craftando Lava
        if (toAuxCraft("FOGO","PEDRA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_LAVA", "LAVA", iconElementosLava);
            setFinishPendencia("LAVA", true);
        }

        // Craftando Mar 
        if (toAuxCraft("MAR","TERRA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_ILHA", "ILHA", iconElementosIlha);
            setFinishPendencia("ILHA", true);
        }

        // Craftando Vulcao 
        if (toAuxCraft("LAVA", "TERRA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_VULCAO", "VULCAO", iconElementosVulcao);
            setFinishPendencia("VULCÃO", true);
        }

        // Craftando Arquipelago 
        if (toAuxCraft("ILHA", "ILHA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_ARQUIPELAGO", "ARQUIPELAGO", iconElementosArquipelago);
            setFinishPendencia("ARQUIPELAGO", true);
        }

        // Craftando Continente 
        if (toAuxCraft("TERRA", "PEDRA")) {
            addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_CONTINENTE", "CONTINENTE", iconElementosContinente);
            setFinishPendencia("CONTINENTE", true);
        }

        slotCraft02[1].SetActive(false);
        slotCraft01[1].SetActive(false);
    }

    void setFinishPendencia(string pendencia, bool finished) {

        int cont;
        string texto;

        for (cont = 0; cont < listPendencias.Length; cont++) {
            texto = listPendencias[cont].GetComponent<Text>().text;
            if (texto.Equals(pendencia)) {
                listPendencias[cont].GetComponent<Text>().color = Color.green;
            }
        }

    }

}