using UnityEngine;

public class PlayerController : Personagem
{
    
    // Componentes do personagem
    private CharacterController characterController;
    [Header("= = PLAYER = =")]
    // Configurações de movimento e pulo
    [SerializeField] float forcaPulo; // Força do pulo
    [SerializeField] float forcaGravidade; // Intensidade da gravidade
    [SerializeField] int moedas;

    private float velocidadeVertical; // Velocidade vertical usada para aplicar gravidade e pulo 
    private float hAxis, vAxis; // Processa o movimento horizontal do personagem

    void Start()
    {
        
        // Inicializa os componentes no início
        animador = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        velocidadeVertical = 0; // Inicializa a velocidade vertical
        gameManager = GameManager.GetInstance();
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

    public bool isDead() 
    {
        if (vida <= 0)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AtkInimigo") 
        {
            if (!isDead()) 
            {
                EnemyController inimigo = other.GetComponentInParent<EnemyController>();
                LevarDano(inimigo.dano);
            }
        }
        if (other.tag == "Treasure") 
        {
            animador.SetTrigger("vitoria");
        }
        
        Item item = other.GetComponent<Item>();
        if (item != null) 
        {
            item.UsarItem(this);
        }
    }

    protected override void Morrer() 
    {
        animador.SetBool("morte", true);
    }

    public void SetDano(int qtdDano) 
    {
        dano += qtdDano;
    }

    public void SetMoeda(int qtdMoeda)
    {
        moedas += qtdMoeda;
    }

}
