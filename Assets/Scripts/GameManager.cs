using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager instance;
    public PlayerController playerController;

    void Awake()
    {
        instance = this;
    }

    public static GameManager GetInstance() 
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

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
