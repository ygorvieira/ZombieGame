using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade = 2;
    private Rigidbody rigibodyInimigo;
    private Animator animatorInimigo;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");

        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

        rigibodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        float distancia = Vector3.Distance
            (transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigibodyInimigo.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigibodyInimigo.MovePosition
                (rigibodyInimigo.position +
                direcao.normalized * Velocidade * Time.deltaTime);

            animatorInimigo.SetBool("Atacando", false);
        }
        else
        {
            animatorInimigo.SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);

        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
