using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEsqueleto : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float velocidade = 6.5f;
    public float forca = 100f;
    public bool liberaPersonagem = false;
    public float distancia;
    public Transform heroi;
    public Animator animacao;
    public bool face = false;
    public Rigidbody2D esqueleto;
    void Start()
    {
        animacao = GetComponent<Animator>();
        esqueleto = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.transform.position, heroi.transform.position);
        VerificarFace();
        Mover();
       
    }

    void Flip()
    {
        face = !face;
        Vector3 escala = this.transform.localScale;
        escala.x *= -1;
        this.transform.localScale = escala;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.CompareTag("Player"))
        {
            liberaPersonagem = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("caixa"))
        {
            Pular();
        }
    }

    



    void Mover()
    {
        if (liberaPersonagem == true && distancia > 2.5f)
        {
            animacao.SetBool("idle", false);
            animacao.SetBool("walk", true);
            if (heroi.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
            }
            else if (heroi.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            }
        }
    }

    void VerificarFace()
    {
        if (heroi.transform.position.x > this.transform.position.x && !face)
        {
            Flip();
        }
        else if (heroi.transform.position.x < this.transform.position.x && face)
        {
            Flip();
        }
    }

    public void Pular()
    {
        
            esqueleto.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
            animacao.SetBool("idle", false);
            animacao.SetBool("walk", false);
            animacao.SetBool("jump", true);
    }

}

