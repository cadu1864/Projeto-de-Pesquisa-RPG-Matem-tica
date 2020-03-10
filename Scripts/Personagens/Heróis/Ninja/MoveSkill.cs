using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkill : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidade = 10f;

    public float Velocidade
    {
        get { return velocidade;}
        set { velocidade = value; }
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    public void Move()
    {
        Vector3 aux = transform.position;
        aux.x += velocidade * Time.deltaTime;
        transform.position = aux;
    }
}
