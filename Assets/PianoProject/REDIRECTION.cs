using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REDIRECTION : MonoBehaviour
{
    public GameObject camera;
    public GameObject torotate;
    private Vector3 beforeRotation;

    float timer;
    int waiting;
    // Start is called before the first frame update
    void Start()
    {

         timer = 0.0f;
        waiting = 2;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (camera.transform.rotation.y >= 45.0f)
        {
            timer += Time.deltaTime;
            if (timer > waiting)
            {
                camera.transform.Rotate(0, -3.0f * Time.deltaTime, 0);
                timer = 0;
            }
        }
        else if (camera.transform.rotation.y <= -45.0f)
        {
            timer += Time.deltaTime;
            if (timer > waiting)
            {
                camera.transform.Rotate(0, 3.0f * Time.deltaTime, 0);
                timer = 0;
            }
        }
        if(camera.transform.rotation.y < 45.0f && camera.transform.rotation.y > -45.0f)
        {
            torotate.transform.Rotate(0, 0, 0);
        }

    }
}
