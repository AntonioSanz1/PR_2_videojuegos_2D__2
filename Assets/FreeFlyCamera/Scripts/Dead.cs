using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{



    private GameObject personaje;
    
    private SaltoBien movPersonaje;
    



    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        movPersonaje = personaje.GetComponent<SaltoBien>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.name == "Personaje")
        {
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
            movPersonaje.Respawnear();

        }
    }


}
