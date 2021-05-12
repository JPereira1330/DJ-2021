using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Fluxo : MonoBehaviour
{

    public void CarregarFase1()
    {
        SceneManager.LoadScene("Introducao");
    }

    public void Sair()
    {
        Application.Quit();
    }

}