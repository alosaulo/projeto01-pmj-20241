using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Componentes do personagem
    private Animator animador;
    private CharacterController characterController;
    private GameManager gameManager;

    // Configurações de movimento e pulo
    [SerializeField] float velocidade; // Velocidade de movimento do personagem
    [SerializeField] float forcaPulo; // Força do pulo
    [SerializeField] float forcaGravidade; // Intensidade da gravidade
    [SerializeField] float vida;
    [SerializeField] bool morreu;

    [SerializeField] Item[] inventario;

    public Item[] Inventario { get { return inventario; } set { inventario = value; } }

    private float velocidadeVertical; // Velocidade vertical usada para aplicar gravidade e pulo 
    private float hAxis, vAxis; // Processa o movimento horizontal do personagem

    void Start()
    {
        // Inicializa os componentes no início
        animador = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        velocidadeVertical = 0; // Inicializa a velocidade vertical
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!isDead()) 
        { 
            if (characterController.isGrounded)
            {
                Pulo(); // Processa o pulo apenas se o personagem estiver no chão
                Atacar();
            }
            // Lida com as funções de movimento e animação a cada frame
            Movimento();
        }
        Gravidade(); // Aplica gravidade constantemente
        Animacoes(); // Atualiza as animações baseadas no estado do personagem

        if (Input.GetKeyDown(KeyCode.P)) 
        {
            SetVida(5);
            inventario[1] = null;
        }
        if (isDead()) 
        {
            animador.SetBool("morte", true);
        }
    }

    void Atacar() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            animador.SetTrigger("atk1");
        }
    }

    void Movimento()
    {
        
        hAxis = Input.GetAxis("Horizontal"); // Entrada horizontal (A/D ou setas esquerda/direita)
        vAxis = Input.GetAxis("Vertical"); // Entrada vertical (W/S ou setas cima/baixo)

        // Calcula a direção e a velocidade do movimento
        Vector3 moveDirection = transform.forward * vAxis;
        
        Vector3 velocity = moveDirection * velocidade * Time.deltaTime + 
            Vector3.up * velocidadeVertical * Time.deltaTime;

        // Rotaciona o personagem baseado na entrada horizontal
        transform.Rotate(0, hAxis, 0);

        // Move o personagem com base na velocidade calculada
        characterController.Move(velocity);
    }

    void Pulo()
    {
        // Processa o pulo quando a tecla de espaço é pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica a força do pulo para a velocidade vertical
            velocidadeVertical += Mathf.Sqrt(forcaPulo * forcaGravidade);
        }
    }

    void Gravidade()
    {
        // Aplica a gravidade ao personagem
        if (!characterController.isGrounded)
        {
            animador.SetBool("jump", true);
            // Se o personagem não estiver no chão, aumenta a velocidade vertical negativa
            velocidadeVertical -= forcaGravidade * Time.deltaTime;
        }
        else 
        {
            animador.SetBool("jump", false);
            velocidadeVertical = -1;
        }
    }

    void Animacoes()
    {

        // Controla as animações do personagem
        bool isRunning = Mathf.Abs(vAxis) > 0.1f && characterController.isGrounded;

        // Ativa a animação de corrida se o personagem estiver se movendo e no chão
        animador.SetBool("param_idletorunning", isRunning);
    }

    public void SetVida(float qtdVida) 
    {
        vida += qtdVida;
    }

    public bool isDead() 
    {
        if (vida <= 0)
            return true;
        else
            return false;
    }

    public void LevarDano(int qtd)
    {
        vida -= qtd;
        animador.SetTrigger("dano");
        if (vida <= 0)
        {
            Morrer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AtkInimigo") 
        {
            if(!isDead())
                LevarDano(1);
        }
        if (other.tag == "Treasure") 
        {
            animador.SetTrigger("vitoria");
        }
    }

    public void Morrer() 
    {
        animador.SetBool("morte", true);
    }

}
