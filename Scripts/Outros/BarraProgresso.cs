using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraProgresso : MonoBehaviour
{
    public GameObject barraProgresso;
    public StatusBarra statusBarra;
    public Text textoProgesso;
    public float maximoProgresso;
    public float progressoAtual;
    // Start is called before the first frame update
    void Start()
    {
        statusBarra = this.gameObject.GetComponent<StatusBarra>();
    }

    // Update is called once per frame
    void Update()
    {
        barraProgresso.transform.localScale = new Vector3(statusBarra.PegarTamanhoBarra(progressoAtual, maximoProgresso), barraProgresso.transform.localScale.y, barraProgresso.transform.localScale.z);
        textoProgesso.text = statusBarra.PegarPorcentagemBarra(progressoAtual, maximoProgresso, 100) + "%";

        if(progressoAtual<maximoProgresso)
        {
            progressoAtual += Time.deltaTime * 6;
            if(progressoAtual > 52)
            {
                textoProgesso.color = UnityEngine.Color.white;
            }
        }
        else
        {
            textoProgesso.text = statusBarra.PegarPorcentagemBarra(progressoAtual, maximoProgresso, 100) + "% completo";
            SceneManager.LoadScene("Tela Inicial");
        }
    }
}
