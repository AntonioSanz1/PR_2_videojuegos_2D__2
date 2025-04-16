using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{

    GameObject personaje;

    bool bolaDerecha = true;

    public float speedBala = 2.0f;


    float tiempoDestrucción = 5.0f;

    float queHoraEs;


    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        bolaDerecha = personaje.GetComponent<SaltoBien>().miraDerecha;


        queHoraEs = Time.time;


    }

    // Update is called once per frame
    void Update()
    {

    if(bolaDerecha){
        transform.Translate(speedBala* Time.deltaTime, 0, 0, Space.World);
    }else{
        transform.Translate((speedBala* Time.deltaTime)*-1, 0, 0, Space.World);
    }
    
    //Debug.Log(Time.time);
    if(Time.time >= queHoraEs+tiempoDestrucción){
        Destroy(this.gameObject);
    }


    }


    void OnTriggerEnter2D(Collider2D col){
       
       // Debug.Log(col.gameObject.name.StartsWith("Fantasma"));

       /* 
        if(col.gameObject.name.StartsWith("Fantasma")){
            Destroy(col.gameObject);
        }
        */

        if(col.gameObject.tag == "Enemigo"){
            Destroy(col.gameObject);
            
            GameManager.muertes +=1;

            Destroy(this.gameObject);
        }





    }
}
