using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJGrow : MonoBehaviour
{


    private Vector3 originalScale;
    private Coroutine currentCoroutine;



    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grow(float multiplier, float duration)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            transform.localScale = originalScale; // Reset si se toma otro ítem antes de acabar
        }

        currentCoroutine = StartCoroutine(GrowCoroutine(multiplier, duration));
    }

    private IEnumerator GrowCoroutine(float multiplier, float duration)
    {
        transform.localScale = originalScale * multiplier;
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
        currentCoroutine = null;
    }



}
