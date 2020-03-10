using UnityEngine;


public class MoveEsqueleto : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float velocidade = 6.5f;
    public float forca = 100f;
    public bool liberaPersonagem = true;
    public float distancia;
    public Transform heroi;
    public Animator animacao;
    public bool face = false;
    public Rigidbody2D esqueleto;
    public CapsuleCollider2D colisor;

    public bool vivo = true;

    public int DanoMorte = 0;

    public GameObject explosao;

    public bool liberaAtaque = false;

    public int qtd = 0;
    void Start()
    {
        animacao = GetComponent<Animator>();
        esqueleto = GetComponent<Rigidbody2D>();
        colisor = GetComponent<CapsuleCollider2D>();
        DanoMorte = GerarNumeroAleatorio();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vivo == true)
        {
            distancia = Vector2.Distance(this.transform.position, heroi.transform.position);
            ReceberDano();
            VerificarFace();
            Mover();
            Atacar();
            liberaPersonagem = true;
        }
        
       
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
            liberaAtaque = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            liberaAtaque = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("caixa"))
        {
            Pular();
        }
        /*if(outro.gameObject.CompareTag("atacar"))
        {
            contadorAtaque++;
            Destroy(outro.gameObject);
        }*/
        
    }

    void Mover()
    {
        if (liberaPersonagem == true && distancia > 2.5f && velocidade > 0 && !liberaAtaque)
        {
            animacao.SetBool("idle", false);
            animacao.SetBool("walk", true);
            animacao.SetBool("atk1", false);
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

    public void ReceberDano()
    {
        bool liberaAtaque = heroi.GetComponent<MoveNinja>().liberaAtaque;
        bool faceHeroi = heroi.GetComponent<MoveNinja>().face;
        bool atacando = heroi.GetComponent<MoveNinja>().atacando;
        int contadorAtaque = heroi.GetComponent<MoveNinja>().contadorAtaque;
        if (liberaAtaque == true && faceHeroi == !face && atacando == true)
        {
            
            
            if (contadorAtaque == DanoMorte)
            {
                vivo = false;
                animacao.SetBool("idle", false);
                animacao.SetBool("walk", false);
                animacao.SetBool("jump", false);
                animacao.SetBool("atk1", false);
                animacao.SetBool("dead", true);
                velocidade = 0;
                colisor.isTrigger = true;
                esqueleto.constraints = RigidbodyConstraints2D.FreezePositionY;
                

                Instantiate(explosao, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                
                print("Entrou");
                //Destroy(this.gameObject);
            }
            else if (contadorAtaque > DanoMorte)
            {
                contadorAtaque = DanoMorte;
            }
        }
    }

    public void Atacar()
    {
        bool atacando = heroi.GetComponent<MoveNinja>().atacando;
        if (liberaAtaque== true && atacando == true && vivo == true)
        {
            animacao.SetBool("idle", false);
            animacao.SetBool("walk", false);
            animacao.SetBool("atk1", true);
            
        }
        else if(liberaAtaque == true && atacando == false && vivo == true)
        {
            animacao.SetBool("idle", false);
            animacao.SetBool("walk", false);
            animacao.SetBool("atk1", true);
            qtd++;
            if (qtd == 10)
            {
                heroi.GetComponent<MoveNinja>().vidaNinja -= 1;
                qtd = 0;
            }
        }
        
    }

    public int GerarNumeroAleatorio()
    {
        int numeroAleatorio = Random.Range(1, 5);
        return numeroAleatorio;
    }

}

