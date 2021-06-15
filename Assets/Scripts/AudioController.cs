using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour{

    private Slider slider;
    private AudioSource musica_principal;
    private AudioSource musica_Jogo;
    private AudioSource musica_Introducao;
    private AudioSource musica_Introducao2;

    private float volume_principal;
    private float volume_musica;

    void Start(){
        if(SceneManager.GetActiveScene().name.Equals("Menu")) {
            musica_principal = GameObject.FindGameObjectWithTag("Musica_Menu").GetComponent<AudioSource>();
            
        }
    }

    void Update() {
        if(SceneManager.GetActiveScene().name.Equals("Introducao")){
            if(musica_Introducao == null){
                musica_Introducao = GameObject.FindGameObjectWithTag("Musica_Intro").GetComponent<AudioSource>();
                musica_Introducao2 = GameObject.FindGameObjectWithTag("Musica_Intro2").GetComponent<AudioSource>();
            } else {
                if(volume_musica!=0){
                    musica_Introducao.volume = volume_musica;
                    musica_Introducao2.volume = volume_musica;
                }
            }
        }
        if(SceneManager.GetActiveScene().name.Equals("GamePlay")){
            if(musica_principal != null){
                musica_principal.Stop();
            }
            if(musica_Jogo == null){
                musica_Jogo = GameObject.FindGameObjectWithTag("Musica_Game").GetComponent<AudioSource>();
                if(volume_principal!=0){
                    musica_Jogo.volume = volume_principal;
                }
            }
        }
        if(SceneManager.GetActiveScene().name.Equals("Menu")){
            if(volume_principal != 0){
                musica_principal.volume = volume_principal;
            }
        }
    }

    public void trocaValumeMusica(Slider vol) {
        float valor = (vol.value)/100; 
        volume_musica = valor;

    }

    public void trocaValumePrincipal(Slider vol) {
        float valor = (vol.value)/100; 
        volume_principal = valor;
    }

}