using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Velocidade = 20;
    private Rigidbody rigibodyBala;

    void Start()
    {
        rigibodyBala = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate () {
        rigibodyBala.MovePosition
            (rigibodyBala.position + 
            transform.forward * Velocidade * Time.deltaTime);
	}

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
        }

        Destroy(gameObject);
    }
}
