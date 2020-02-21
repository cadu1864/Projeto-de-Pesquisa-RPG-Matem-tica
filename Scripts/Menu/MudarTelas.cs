using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarTelas : MonoBehaviour
{
   

    void Start()
    {


    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NovoJogo()
    {
        SceneManager.LoadScene("Tela de Anos");
    }

    public void CarregarReinoNumerosSextoAno()
    {
        print("Entrou 1");
        SceneManager.LoadScene("6AnoReinoNumeros");
        
    }
    public void CarregarReinosSextoAno()
    {
        SceneManager.LoadScene("Escolha de Reinos");
    }

    public void CarregarFaseInicialNumeros()
    {
        print("Entrou 2");
        SceneManager.LoadScene("Cena Inicial");
    }
}
