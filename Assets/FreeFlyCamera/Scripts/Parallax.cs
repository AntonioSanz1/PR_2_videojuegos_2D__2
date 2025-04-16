using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float parallaxSpeed = 3;

    //GameObject miCamara;

    // Start is called before the first frame update
    void Start()
    {
        //miCamara = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Camera.main.transform.position);

        transform.position = new Vector3(Camera.main.transform.position.x/parallaxSpeed, Camera.main.transform.position.y/parallaxSpeed, 0);



    }
}
