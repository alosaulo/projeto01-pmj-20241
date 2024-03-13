using System;

[System.Serializable]
public class Item
{
    public string nome;
    public float peso;
    public float durabilidade;
    public float valor;

    public Item() { }

    public Item(string nome, float peso, float durabilidade, float valor)
    {
        this.nome = nome;
        this.peso = peso;
        this.durabilidade = durabilidade;
        this.valor = valor;
    }


}
