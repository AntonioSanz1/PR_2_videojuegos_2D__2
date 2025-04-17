using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaltoBien : MonoBehaviour
{

    public float multiplicador = 5f;

    public float multiplicadorSalto = 3f;

    private Rigidbody2D rb;

    private bool puedoSaltar = true;
    private bool activaSaltoFixed = false;

    public bool miraDerecha = true;

    private Animator animatorController;

    private GameObject respawn;

    float movTeclas;
    
    bool soyMagenta;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //transform.position = new Vector3(-5.04f,0.73f,0);

        animatorController = this.GetComponent<Animator>();


        //Respawn
        respawn = GameObject.Find("Respawn");
        Respawnear();
        

    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.estoyMuerto) return;


        //Debug.Log("Hola mi gente hermosota");


        movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
        //movTeclas = Input.GetAxis("Vertical"); //(a - 1f - d 1f)

        //movimiento
      /*  transform.position = new Vector3(
            transform.position.x+(movTeclas/100),
            transform.position.y,
            transform.position.z
        );*/        



        //movimiento
        float miDeltaTime = Time.deltaTime;

        Debug.Log(Time.deltaTime);

        transform.Translate(
            movTeclas*(Time.deltaTime*multiplicador),
            0,
            0
        );



        //movimiento personaje
        //rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);


        /*
        //Flip izq
        if(Input.GetKeyDown(KeyCode.D)){
            this.GetComponent<SpriteRenderer>().flipX = false;
            //transform.localScale = new Vector3(transform.localScale.x*1,transform.localScale.y,transform.localScale.z);

        }

        //Flip der
        if(Input.GetKeyDown(KeyCode.A)){
           this.GetComponent<SpriteRenderer>().flipX = true;
           //transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        */
        
        //Flip ultimo método
        //izq
        if(movTeclas > 0){
            this.GetComponent<SpriteRenderer>().flipX = false;
            miraDerecha = true;
        //der
        }else if(movTeclas <0 ){
           this.GetComponent<SpriteRenderer>().flipX = true;
           miraDerecha = false;
        }

        //movimiento o quietos Animacion Walking
        if(movTeclas !=0){
            animatorController.SetBool("ActivarCaminar", true);
        }else{
            animatorController.SetBool("ActivarCaminar", false);
        }

        //SALTO
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);


        //Salto
        if(hit){
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else{
            puedoSaltar = false;
        }

        //salto
        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
            activaSaltoFixed = true;

            //PuedoSaltarFixed
            /*
            rb.AddForce(
                new Vector2(0, multiplicadorSalto),
                ForceMode2D.Impulse
            );
            */
            //puedoSaltar = false;
        }



        //comprobobar si me he salido de la pantalla por abajo
        
        if(transform.position.y <= -7.50f){
            Respawnear();
        }


        // 0 vidas

        if(GameManager.vidas <= 0)
        {
            GameManager.estoyMuerto = true;

        }





    }

    /*
    void OnCollisionEnter2D(){
        puedoSaltar = true;

    }
    */


    void FixedUpdate(){
        
        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);
        
        if(activaSaltoFixed == true){
            rb.AddForce(
                new Vector2(0, multiplicadorSalto),
                ForceMode2D.Impulse
            );
            activaSaltoFixed = false;
        }

            

    }


    public void Respawnear(){

        Debug.Log("vidas: "+GameManager.vidas);
        GameManager.vidas = GameManager.vidas - 1;
        Debug.Log("vidas: "+GameManager.vidas);

        transform.position = respawn.transform.position;
    }

    public void CambiarColor(){

        if(soyMagenta){
            this.GetComponent<SpriteRenderer>().color = Color.white;
            soyMagenta = false;
        }else{
            this.GetComponent<SpriteRenderer>().color = Color.magenta;
            soyMagenta = true;
        }



    }



}
