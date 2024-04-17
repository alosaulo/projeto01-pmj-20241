using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkManager : MonoBehaviour
{
    [SerializeField] GameObject AtkInimigo;

    public void AtivarAtk()
    {
        AtkInimigo.SetActive(true);
    }

    public void DesativarAtk()
    {
        AtkInimigo.SetActive(false);
    }

}
