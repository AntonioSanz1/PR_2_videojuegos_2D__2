using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int vidas = 4;

    public static int puntos = 0;

    public static int muertes = 0;
    
    public static bool estoyMuerto = false;

    GameObject vidasText;


    // Start is called before the first frame update
    void Start()
    {
        vidasText = GameObject.Find("VidasText");
    }

    // Update is called once per frame
    void Update()
    {

     Debug.Log("Puntos: "+puntos);
     Debug.Log("Muertes: "+muertes);
     
        vidasText.GetComponent<TextMeshProUGUI>().text = vidas.ToString();

    }
}
