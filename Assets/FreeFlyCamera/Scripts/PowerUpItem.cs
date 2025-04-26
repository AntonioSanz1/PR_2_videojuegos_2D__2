using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{


    public float scaleMultiplier = 2f; // Cuánto se agranda el personaje
    public float duration = 5f; // Duración del efecto


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PJGrow growScript = other.GetComponent<PJGrow>();
            if (growScript != null)
            {
                growScript.Grow(scaleMultiplier, duration);
            }

            Destroy(gameObject); // Elimina el ítem tras recogerlo
        }
    }



}
