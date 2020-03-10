using UnityEngine;

public class MoveNinja : MonoBehaviour
{
    public Transform heroiT;
    //public Transform esqueleto;
    public bool face = true;
    public Vector3 escala;
    public Animator animacao;
    public float velocidade = 0;
    public float forca = 350f;
    public Rigidbody2D heroi;

    public bool liberaPulo = false;
    public Transform check;
    public LayerMask chao;
    public float raio = 0.2f; 
    public int unico = 1;


    public bool liberaAtaque = false;
    public bool atacando = false;
    public bool pulando = false;

    public int contadorAtaque = 0;

    public bool vivo = true;
    public int vidaNinja = 10;



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
        if (vivo == true)
        {
            escala = heroiT.localScale;
            Mover();
            liberaPulo = Physics2D.OverlapCircle(check.position, raio, chao);
        }
    }

    public void MoveDireita()
    {
        if (!face)
        {
            Flip();
        }
        animacao.SetBool("idle", false);
        animacao.SetBool("run", true);
        velocidade = 20*Time.deltaTime;
        

    }

    public void MoveEsquerda()
    {
        if (face)
        {
            Flip();
        }
        animacao.SetBool("idle", false);
        animacao.SetBool("run", true);
        velocidade = -20*Time.deltaTime;
        

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
            pulando = false;
        }
    }

    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao") || outro.gameObject.CompareTag("caixa"))
        {
            unico = 1;
            pulando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("esqueleto"))
        {
            liberaAtaque = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("esqueleto"))
        {
            liberaAtaque = false;

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
        atacando = true;

        if (liberaAtaque == true)
        {
            
            contadorAtaque++;
            

        }
        else
        {
            atacando = false;
        }


    }

    public void ReceberDano()
    {
        
        
    }



}
