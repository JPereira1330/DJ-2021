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
    public Sprite iconElementoBacteria;
    public Sprite iconElementoVapor;
    public Sprite iconElementoLama;
    public Sprite iconElementoMateriaOrganica;
    public Sprite iconElementoOzonio;
    public Sprite iconElementoOceano;
    public Sprite iconElementoPlanta;
    public Sprite iconElementoSemente;
    public Sprite iconElementoArvore;
    public Sprite iconElementoVida;
    public Sprite iconElementoIdeia;
    public Sprite iconElementoAnimal;
    public Sprite iconElementoMacaco;
    public Sprite iconElementoPeixe;
    public Sprite iconElementoFerramenta;
    public Sprite iconElementoHumano;
    public Sprite iconElementoFilosofia;
    public Sprite iconElementoEngenharia;
    public Sprite iconElementoMaquina;
    public Sprite iconElementoComputador;

    public AudioClip[] audioController;
    public Sprite[] planetas;

    void Start(){

        // Inicializacoes objetos
        planetaTerra = GameObject.FindGameObjectWithTag("OBJ_TERRA");
        slotCraft01 = GameObject.FindGameObjectsWithTag("CRAFT_SLOT_01");
        slotCraft02 = GameObject.FindGameObjectsWithTag("CRAFT_SLOT_02");
        listElementos = GameObject.FindGameObjectsWithTag("ELEMENTO");
        listPendencias = GameObject.FindGameObjectsWithTag("LIST_PENDENCIA");
        levelController = GameObject.FindGameObjectWithTag("Finish");
        GameObject.FindGameObjectWithTag("EditorOnly").SetActive(true);
        
        // Inicializando valores
        capitulo = 3;
        quantiaElementosSalvo = 0;
        slotCraft01[1].SetActive(false);
        slotCraft02[1].SetActive(false);
        levelController.SetActive(false);

        // Iniciando valores da array de pendecias
        for (int cont = 0; listPendencias.Length > cont; cont++) {
            listPendencias[cont].GetComponent<Text>().color = Color.red;
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

        for (int cont = 0; listElementos.Length > cont; cont++) {
            listElementos[cont].tag = "ELEMENTO";
        }

        for (int i = 0; i < listPendencias.Length; i++) {
            listPendencias[i].GetComponent<Text>().color = Color.red;
        }

        GetComponent<AudioSource>().clip = audioController[1];
        GetComponent<AudioSource>().Play();

        switch (capitulo) {
            case 1:
                initCapitulo01();
                break;
            case 2:
                initCapitulo02();
                break;
            case 3:
                initCapitulo03();
                break;
        }
    }

    async void initCapitulo01() {

        Animator animacao;
        string[] capitulo01 = new string[4];

        // Configurando animação
        levelController.SetActive(true);
        GameObject.FindGameObjectWithTag("LEVEL_TITLE").GetComponent<Text>().text = "C A P I T U L O  -  0 1";
        GameObject.FindGameObjectWithTag("LEVEL_SUBTITLE").GetComponent<Text>().text = "CRIAÇÃO DO PLANETA";

        // Realizando animação de troca
        animacao = levelController.GetComponent<Animator>();
        animacao.SetTrigger("FadeOut");
        GameObject.FindGameObjectWithTag("OBJ_TERRA").GetComponent<Image>().sprite = planetas[0];

        await Task.Delay(2000);
        GameObject.FindGameObjectWithTag("EditorOnly").SetActive(false);

        capitulo01[0] = "ELEMENTO_AGUA";
        capitulo01[1] = "ELEMENTO_FOGO";
        capitulo01[2] = "ELEMENTO_TERRA";
        capitulo01[3] = "ELEMENTO_PEDRA";

        addElements(capitulo01);

        await Task.Delay(3500);
        levelController.SetActive(false);
    }

    async void initCapitulo02() {

        Animator animacao;
        string[] capitulo02 = new string[5];

        // Configura animacao
        levelController.SetActive(true);
        GameObject.FindGameObjectWithTag("LEVEL_TITLE").GetComponent<Text>().text = "C A P I T U L O  -  0 2";
        GameObject.FindGameObjectWithTag("LEVEL_SUBTITLE").GetComponent<Text>().text = "TRANSFORMAÇÃO DO PLANETA";

        // Realizando animação de troca
        animacao = levelController.GetComponent<Animator>();
        animacao.SetTrigger("FadeOut");
        
        await Task.Delay(1500);

        // Elemento inicicias
        capitulo02[0] = "ELEMENTO_AGUA";
        capitulo02[1] = "ELEMENTO_FOGO";
        capitulo02[2] = "ELEMENTO_TERRA";
        capitulo02[3] = "ELEMENTO_LAVA";
        capitulo02[4] = "ELEMENTO_MAR";
        addElements(capitulo02);

        // Adicionando lista de pendencias
        listPendencias[0].GetComponent<Text>().text = "BACTERIA";
        listPendencias[1].GetComponent<Text>().text = "VAPOR";
        listPendencias[2].GetComponent<Text>().text = "LAMA";
        listPendencias[3].GetComponent<Text>().text = "MATERIA ORGANICA";
        listPendencias[4].GetComponent<Text>().text = "OCEANO";
        listPendencias[5].GetComponent<Text>().text = "OZONIO";
        listPendencias[6].GetComponent<Text>().text = "PLANTA";
        listPendencias[7].GetComponent<Text>().text = "SEMENTE";
        listPendencias[8].GetComponent<Text>().text = "ARVORE";
        listPendencias[9].GetComponent<Text>().text = "VIDA";

        GameObject.FindGameObjectWithTag("OBJ_TERRA").GetComponent<Image>().sprite = planetas[1];

        // Alterando variaveis
        GameObject.FindGameObjectWithTag("TLT_GP_ANO").GetComponent<Text>().text = "3 BILHOES DE ANOS ATRAS";
        GameObject.FindGameObjectWithTag("TLT_GP_CAP").GetComponent<Text>().text = "TERRA - Capitulo 02";
        await Task.Delay(3500);
        levelController.SetActive(false);
    }

    async void initCapitulo03() {

        Animator animacao;
        string[] capitulo03 = new string[5];

        // Configura animacao
        levelController.SetActive(true);
        GameObject.FindGameObjectWithTag("LEVEL_TITLE").GetComponent<Text>().text = "C A P I T U L O  -  0 3";
        GameObject.FindGameObjectWithTag("LEVEL_SUBTITLE").GetComponent<Text>().text = "TRANSFORMAÇÃO DA VIDA";

        // Realizando animação de troca
        animacao = levelController.GetComponent<Animator>();
        animacao.SetTrigger("FadeOut");

        await Task.Delay(1500);

        // Elemento inicicias
        capitulo03[0] = "ELEMENTO_VIDA";
        capitulo03[1] = "ELEMENTO_TERRA";
        capitulo03[2] = "ELEMENTO_ARVORE";
        capitulo03[3] = "ELEMENTO_MAR";
        capitulo03[4] = "ELEMENTO_IDEIA";
        addElements(capitulo03);

        // Adicionando lista de pendencias
        listPendencias[0].GetComponent<Text>().text = "ANIMAL";
        listPendencias[1].GetComponent<Text>().text = "MACACO";
        listPendencias[2].GetComponent<Text>().text = "PEIXE";
        listPendencias[3].GetComponent<Text>().text = "FERRAMENTA";
        listPendencias[4].GetComponent<Text>().text = "HUMANO";
        listPendencias[5].GetComponent<Text>().text = "FILOSOFIA";
        listPendencias[6].GetComponent<Text>().text = "ENGENHARIA";
        listPendencias[7].GetComponent<Text>().text = "MAQUINA";
        listPendencias[8].GetComponent<Text>().text = "COMPUTADOR";

        GameObject.FindGameObjectWithTag("OBJ_TERRA").GetComponent<Image>().sprite = planetas[2];

        // Alterando variaveis
        GameObject.FindGameObjectWithTag("TLT_GP_ANO").GetComponent<Text>().text = "2 MILHOES DE ANOS ATRAS - > ATUAL";
        GameObject.FindGameObjectWithTag("TLT_GP_CAP").GetComponent<Text>().text = "TERRA - Capitulo 03";
        await Task.Delay(3500);
        levelController.SetActive(false);
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

        for (int cont = 0; listPendencias.Length > cont; cont++) {
            listPendencias[cont].GetComponent<Text>().color = Color.red;
        }

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

                case "ELEMENTO_VIDA":
                    titulo = "VIDA";
                    img = iconElementoVida;
                    break;

                case "ELEMENTO_ARVORE":
                    titulo = "ARVORE";
                    img = iconElementoArvore;
                    break;

                case "ELEMENTO_IDEIA":
                    titulo = "IDEIA";
                    img = iconElementoIdeia;
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
        listElementos[index].GetComponent<Button>().onClick.RemoveAllListeners();
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

        if (capitulo == 1) {
            // Craftando Mar
            if (toAuxCraft("AGUA", "AGUA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_MAR", "MAR", iconElementosMar);
                setFinishPendencia("MAR", true);
            }

            // Craftando Lava
            if (toAuxCraft("FOGO", "PEDRA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_LAVA", "LAVA", iconElementosLava);
                setFinishPendencia("LAVA", true);
            }

            // Craftando Mar 
            if (toAuxCraft("MAR", "TERRA")) {
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
        }else if (capitulo == 2) {
            
            // Craftando Bacteria
            if (toAuxCraft("AGUA", "LAVA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_BACTERIA", "BACTERIA", iconElementoBacteria);
                setFinishPendencia("BACTERIA", true);
            }

            // Craftando Vapor
            if (toAuxCraft("AGUA", "FOGO")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_VAPOR", "VAPOR", iconElementoVapor);
                setFinishPendencia("VAPOR", true);
            }

            // Craftando MATERIA ORGANICA
            if (toAuxCraft("BACTERIA", "TERRA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_MAT_ORGANICA", "MATERIA ORGANICA", iconElementoMateriaOrganica);
                setFinishPendencia("MATERIA ORGANICA", true);
            }

            // Craftando OZONIO
            if (toAuxCraft("BACTERIA", "OCEANO")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_OZONIO", "OZONIO", iconElementoOzonio);
                setFinishPendencia("OZONIO", true);
            }

            // Craftando LAMA
            if (toAuxCraft("AGUA", "TERRA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_LAMA", "LAMA", iconElementoLama);
                setFinishPendencia("LAMA", true);
            }

            // Craftando OCEANO
            if (toAuxCraft("MAR", "MAR")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_OCEANO", "OCEANO", iconElementoOceano);
                setFinishPendencia("OCEANO", true);
            }

            // Craftando PLANTA
            if (toAuxCraft("SEMENTE", "SEMENTE")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_PLANTA", "PLANTA", iconElementoPlanta);
                setFinishPendencia("PLANTA", true);
            }

            // Craftando SEMENTE
            if (toAuxCraft("MATERIA ORGANICA", "TERRA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_SEMENTE", "SEMENTE", iconElementoSemente);
                setFinishPendencia("SEMENTE", true);
            }

            // Craftando ARVORE
            if (toAuxCraft("PLANTA", "PLANTA")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_ARVORE", "ARVORE", iconElementoArvore);
                setFinishPendencia("ARVORE", true);
            }

            // Craftando VIDA
            if (toAuxCraft("BACTERIA", "OCEANO")) {
                addElementoOnTable(quantiaElementosSalvo, "ELEMENTO_VIDA", "VIDA", iconElementoVida);
                setFinishPendencia("VIDA", true);
            }

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
                GetComponent<AudioSource>().clip = audioController[0];
                GetComponent<AudioSource>().Play();
            }
        }

    }

}