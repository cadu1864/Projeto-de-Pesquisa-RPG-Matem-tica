using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMascote : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade = 0 ;
    public float forca = 100f;
    public bool liberaPersonagem = false;
    public float distancia;
    public Transform heroi;
    public Animator animacao;
    public bool face = false;
    public Rigidbody2D mascote;
    void Start()
    {
        animacao = GetComponent<Animator>();
        mascote = GetComponent<Rigidbody2D>();
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
        if (outro.gameObject.CompareTag("Player"))
        {
            liberaPersonagem = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("caixa"))
        {
            Pular();
        }
    }





    void Mover()
    {
        bool HeroiPulando = heroi.GetComponent<MoveNinja>().pulando;
        if (liberaPersonagem == true && distancia > 20f && !HeroiPulando)
        {
            velocidade = 20f;
            animacao.SetBool("idle", false);
            animacao.SetBool("run", true);
            if (heroi.transform.position.x < this.transform.position.x && distancia > 10f)
            {
                transform.Translate(new Vector2(-velocidade * Time.deltaTime, 0));
            }
            else if (heroi.transform.position.x > this.transform.position.x && distancia > 10f)
            {
                transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
            }
        }
        else
        {
            Parado();
        }
            
    }

    void VerificarFace()
    {
        if (heroi.transform.position.x > this.transform.position.x && face)
        {
            Flip();
        }
        else if (heroi.transform.position.x < this.transform.position.x && !face)
        {
            Flip();
        }
    }

    public void Pular()
    {

        mascote.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
        animacao.SetBool("idle", false);
        animacao.SetBool("run", false);
        animacao.SetBool("jump", true);
    }

    public void Parado()
    {
        velocidade = 0;
        animacao.SetBool("idle", true);
        animacao.SetBool("run", false);
        animacao.SetBool("jump", false);
    }
}
