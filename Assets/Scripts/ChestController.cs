using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody rb;

    Vector3 vetorTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vetorTarget = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(CalcularDistancia() > 2)
            rb.velocity = vetorTarget * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        { 
            PlayerController player 
                = other.GetComponent<PlayerController>();
            //player.LevarDano();
        }
    }

    float CalcularDistancia() 
    {
        float distancia = Vector3.Distance(transform.position, target.position);
        return distancia;
    }

}
