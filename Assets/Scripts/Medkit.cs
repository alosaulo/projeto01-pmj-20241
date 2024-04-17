using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Item
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, -0.5f, 0);
    }

    public float RecuperarVida() { return valor; }

    public override void UsarItem(PlayerController player)
    {
        base.UsarItem();
        player.SetVida(valor);
    }


}
