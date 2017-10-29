using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour {

    public GameObject Zumbi;
    private float contaTempo = 0;
    public float RespawnZumbi = 1;
    	
	// Update is called once per frame
	void Update () {

        contaTempo += Time.deltaTime;

        if (contaTempo >= RespawnZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contaTempo = 0;
        }        
	}
}
