using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoBien : MonoBehaviour
{

    public float multiplicador = 5f;

    public float multiplicadorSalto = 3f;

    private Rigidbody2D rb;

    private bool puedoSaltar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hola mi gente hermosota");


        float movTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
        float movTeclasY = Input.GetAxis("Vertical"); //(a - 1f - d 1f)

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
        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);


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
        
        //Flipultimo método
        if(movTeclas > 0){
            this.GetComponent<SpriteRenderer>().flipX = false;
        }else if(movTeclas <0 ){
           this.GetComponent<SpriteRenderer>().flipX = true;
        }


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
            rb.AddForce(
                new Vector2(0, multiplicadorSalto),
                ForceMode2D.Impulse
            );
            //puedoSaltar = false;
        }

    }

    /*
    void OnCollisionEnter2D(){
        puedoSaltar = true;

    }
    */


}
