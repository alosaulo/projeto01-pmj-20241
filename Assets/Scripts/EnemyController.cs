using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Personagem
{
    [SerializeField] GameObject particlePrefab;

    [SerializeField] float aggroDist;

    [SerializeField] float distAtk;

    Transform target;

    Rigidbody rigidBody;

    Vector3 pontoInicial;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        target = gameManager.playerController.transform;
        pontoInicial = transform.position;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanciaTarget() > distAtk && DistanciaTarget() < aggroDist)
        {
            PerseguirTarget();
            OlharTarget();
        }
        else if (DistanciaTarget() <= distAtk)
        {
            animador.SetBool("walk", false);
            Atacar();
        }
        else 
        {
            animador.SetBool("walk", false);
        }
            
    }

    void PerseguirTarget()
    {
        animador.SetBool("walk", true);

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
        animador.SetTrigger("atk");
    }

    protected override void Morrer() 
    {
        Instantiate(particlePrefab,
                    gameObject.transform.position,
                    Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AtkPlayer") 
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            LevarDano(player.dano); 
        }
    }
}
