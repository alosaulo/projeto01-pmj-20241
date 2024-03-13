using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject AtkInimigo;

    [SerializeField] int vida;

    [SerializeField] int dano;

    [SerializeField] float velocidade;

    [SerializeField] float aggroDist;

    Transform target;

    Rigidbody rigidBody;

    Animator animator;

    Vector3 pontoInicial;

    int maxVida;


    // Start is called before the first frame update
    void Start()
    {
        pontoInicial = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanciaTarget() > 1.5 && DistanciaTarget() < aggroDist) 
        {
            PerseguirTarget();
            OlharTarget();
        }
        else if(DistanciaTarget() <= 1.5)
        {
            Atacar();
        }
            
    }

    public void SetVida(int qtdVida)
    {
        vida = qtdVida;
    }

    public void LevarDano(int qtd)
    {
        vida -= qtd;
        if (vida <= 0) 
        {
            Morrer();
        }
    }

    void PerseguirTarget()
    {
        Vector3 lerp =
            Vector3.LerpUnclamped(transform.position, target.position, velocidade * Time.deltaTime);

        transform.position = lerp;

    }

    float DistanciaTarget()
    {
        float distancia = Vector3.Distance(transform.position, target.position);
        return distancia;
    }

    void OlharTarget() 
    {
        transform.LookAt(target.position);
        transform.rotation = 
            Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    void Atacar() 
    {
        animator.SetTrigger("atk");
    }

    void Morrer() 
    { 
        Destroy(gameObject);
    }

    public void AtivarAtk() 
    { 
        AtkInimigo.SetActive(true);
    }

    public void DesativarAtk() 
    {
        AtkInimigo.SetActive(false);
    }

}
