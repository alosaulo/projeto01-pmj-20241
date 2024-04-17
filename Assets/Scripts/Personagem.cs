using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personagem : MonoBehaviour
{
    [SerializeField] protected Animator animador;
    [SerializeField] protected GameObject atkTrigger;
    [SerializeField] protected float vida;
    [SerializeField] protected float vidaMax;
    [SerializeField] protected float velocidade;
    [SerializeField] public float dano;
    [SerializeField] protected bool morreu;
    
    protected GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVida(float qtdVida)
    {
        vida += qtdVida;
        if (vida >= vidaMax) 
        { 
            vida = vidaMax;
        }
    }

    public void LevarDano(float qtd)
    {
        vida -= qtd;
        animador.SetTrigger("dmg");
        if (vida <= 0)
        {
            Morrer();
        }
    }

    protected abstract void Morrer();

    public void AtivarAtk() {
        atkTrigger.SetActive(true);
    }

    public void DesativarAtk() {
        atkTrigger.SetActive(false);
    }

}
