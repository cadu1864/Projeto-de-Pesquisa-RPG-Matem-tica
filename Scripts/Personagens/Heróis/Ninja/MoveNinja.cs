using UnityEngine;

public class MoveNinja : MonoBehaviour
{
    public Transform heroiT;
    public bool face = true;
    public Vector3 escala;
    public Animator animacao;
    public float velocidade = 0;
    public float forca = 350f;
    public Rigidbody2D heroi;
    public bool liberaPulo = false;
    public int unico = 1;


    // Start is called before the first frame update
    void Start()
    {
        heroiT = GetComponent<Transform>();
        animacao = GetComponent<Animator>();
        heroi = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        escala = heroiT.localScale;

        Mover();

    }

    public void MoveDireita()
    {
        if (!face)
        {
            Flip();
        }
        animacao.SetBool("idle", false);
        animacao.SetBool("run", true);
        velocidade = 25*Time.deltaTime;
        

    }

    public void MoveEsquerda()
    {
        if (face)
        {
            Flip();
        }
        animacao.SetBool("idle", false);
        animacao.SetBool("run", true);
        velocidade = -25*Time.deltaTime;
        

    }

    public void Parado()
    {
        velocidade = 0;
        animacao.SetBool("idle", true);
        animacao.SetBool("run", false);
        animacao.SetBool("jump", false);
        animacao.SetBool("atk", false);
    }

    public void Mover()
    {
        transform.Translate(new Vector2(velocidade, 0));
    }

    public void Flip()
    {
        
        face = !face;
        escala.x *= -1;
        heroiT.localScale = escala;

    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("caixa"))
        {
            unico = 1;
            liberaPulo = true;
        }
    }



    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("caixa"))
        {
            liberaPulo = false;
        }
    }

    public void Pular()
    {
        if (unico > 0)
        {
            heroi.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
            unico--;
            animacao.SetBool("idle", false);
            animacao.SetBool("jump", true);
        }
    }

    public void Atacar()
    {
        animacao.SetBool("idle", false);
        animacao.SetBool("atk", true);
    }



}
