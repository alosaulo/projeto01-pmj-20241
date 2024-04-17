using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("==ITEM==")]
    public string nome;
    public float duracao;
    public float valor;

    public void InformarStatus() 
    { 
        Debug.Log($"{nome} | {duracao} | {valor}");
    }

    public virtual void UsarItem() 
    {
        InformarStatus();
    }

    public virtual void UsarItem(PlayerController player)
    {
        InformarStatus();
    }

    private void Update()
    {
        
    }

}
