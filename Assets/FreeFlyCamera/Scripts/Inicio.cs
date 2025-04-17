using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{


    GameObject panelSettings;


    // Start is called before the first frame update
    void Start()
    {

        panelSettings = GameObject.Find("PanelSettings");
        panelSettings.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartGame(){

        Debug.Log("play");
        SceneManager.LoadScene("1Escena1");

    }

    public void ExitGame(){

        Debug.Log("exit");

        Application.Quit();

    }




    public void MostrarSettings(){

        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxButton);
        panelSettings.SetActive(true);


    }


    public void OcultarSettings(){
        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxButton);

        panelSettings.SetActive(false);
    }

    public void SuenaBoton(){
        AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxButton);

    }


}
