using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrampaRoca : MonoBehaviour
{

    public Rigidbody2D rBdy;
    public float distanciaLinea;
    public LayerMask capaJugador;

    //saber si el objeto sube o baja
    public bool estaSubiendo = false;
    public float velocidadSubida;

    private SaltoBien movPersonaje;

    private Vector3 posicionInicial;

    


    // Start is called before the first frame update
    void Start()
    {
            GameObject personaje = GameObject.Find("Personaje");
            movPersonaje = personaje.GetComponent<SaltoBien>();

            //saber posición inicial
            posicionInicial = transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log("¿Está subiendo?: " + estaSubiendo);

        
        //Detectar si pasa el personaje por debajo
        RaycastHit2D infoJugador = Physics2D.Raycast(transform.position, Vector3.down, distanciaLinea, capaJugador);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        //El objeto en cuestión no rote y solo baje si no está subiendo
        if(infoJugador && !estaSubiendo){
            rBdy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        //Hacer que el objeto vuelva a subir hasta su posición inicial
     if (estaSubiendo)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadSubida * Time.deltaTime);

            // Cuando llega a la posición inicial
            if (transform.position == posicionInicial)
            {
                estaSubiendo = false;
                rBdy.constraints = RigidbodyConstraints2D.FreezeAll; // Congelarlo al llegar
            }
        }
    }




    //Detectar impacto en Suelo y que pueda volver a subir gracias al bool
     private void OnCollisionEnter2D(Collision2D other)
    {
         Debug.Log("¡Colisión con suelo detectada!");

        if(other.gameObject.layer == LayerMask.NameToLayer("Suelo")){
            
            rBdy.constraints = RigidbodyConstraints2D.FreezeAll;

            if(estaSubiendo)
            {
                estaSubiendo = false;

            }else
            {
                estaSubiendo = true;
            }

        }
    } 


        void OnTriggerEnter2D(Collider2D col){

        if(col.name == "Personaje")
        {
    
            movPersonaje.Respawnear();

        }
    }

    



}
