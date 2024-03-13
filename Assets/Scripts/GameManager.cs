using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Dificuldade dificuldade;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        SelecaoDificuldade();
    }

    void SelecaoDificuldade() 
    {
        if (dificuldade == Dificuldade.Facil)
        {
            playerController.Inventario = GetMasterPack();
        }
        else if (dificuldade == Dificuldade.Medio)
        {
            playerController.Inventario = GetAdvancedPack();
        }
        else if (dificuldade == Dificuldade.Dificil)
        {
            playerController.Inventario = GetStarterPack();
        }
    }

    Item[] GetStarterPack()
    {
        Item espada = new Item("Espada de Ferro", 3, 100, 10);

        /*Item espada = new Item();
        espada.durabilidade = 100;
        espada.valor = 10;
        espada.nome = "Espada de ferro";
        espada.peso = 3;*/

        Item pocaoCura = new Item();
        pocaoCura.durabilidade = 1; // Uma vez que poções são consumíveis e usadas uma única vez
        pocaoCura.valor = 25;
        pocaoCura.nome = "Poção de Cura";
        pocaoCura.peso = 0.5f;

        Item[] itens = {espada, pocaoCura};
        return itens;
    }

    Item[] GetAdvancedPack() {

        Item espada = new Item();
        espada.durabilidade = 100;
        espada.valor = 10;
        espada.nome = "Espada de ferro";
        espada.peso = 3;

        Item pocaoCura = new Item();
        pocaoCura.durabilidade = 1; // Uma vez que poções são consumíveis e usadas uma única vez
        pocaoCura.valor = 25;
        pocaoCura.nome = "Poção de Cura";
        pocaoCura.peso = 0.5f;

        Item escudoMadeira = new Item();
        escudoMadeira.durabilidade = 70;
        escudoMadeira.valor = 8;
        escudoMadeira.nome = "Escudo de Madeira";
        escudoMadeira.peso = 4;

        Item[] itens = { espada, pocaoCura, escudoMadeira };
        return itens;
    }

    Item[] GetMasterPack() {

        Item espada = new Item();
        espada.durabilidade = 100;
        espada.valor = 10;
        espada.nome = "Espada de ferro";
        espada.peso = 3;

        Item pocaoCura = new Item();
        pocaoCura.durabilidade = 1; // Uma vez que poções são consumíveis e usadas uma única vez
        pocaoCura.valor = 25;
        pocaoCura.nome = "Poção de Cura";
        pocaoCura.peso = 0.5f;

        Item escudoMadeira = new Item();
        escudoMadeira.durabilidade = 70;
        escudoMadeira.valor = 8;
        escudoMadeira.nome = "Escudo de Madeira";
        escudoMadeira.peso = 4;

        Item tocha = new Item()
        {
            nome = "Tocha",
            durabilidade = 100,
            peso = 1,
            valor = 3
        };

        Item[] itens = { espada, pocaoCura, escudoMadeira, tocha };
        return itens;
    }

    void Winner() 
    {
        Debug.Log("Você Ganhou!");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
