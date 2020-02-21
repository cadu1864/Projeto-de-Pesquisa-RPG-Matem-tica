using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatusBarra : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float PegarTamanhoBarra(float valorMinimo, float valorMaximo)
    {
        return valorMinimo / valorMaximo;
    }

    public int PegarPorcentagemBarra(float valorMinimo, float valorMaximo, int fator)
    {
        return Mathf.RoundToInt(PegarTamanhoBarra(valorMinimo, valorMaximo) * fator);
    }
}
