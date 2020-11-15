using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    private Vector3 cupposition;
    public GameObject hand;
    public GameObject myprefab;

    public GameObject camera;

    public GameObject bug;
    public GameObject midcup;
    public GameObject leftcup;
    public GameObject rightcup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            if(bug != null)
                Destroy(bug);
            cupposition = hand.transform.position;
            cupposition.y -= midcup.transform.localScale.y;
            midcup.transform.position = cupposition;
            leftcup.transform.position = new Vector3(cupposition.x - 0.1f, cupposition.y, cupposition.z - 0.1f);
            rightcup.transform.position = new Vector3(cupposition.x + 0.1f, cupposition.y, cupposition.z - 0.1f);
        }

        if (camera.transform.rotation.y < -3.0f)
        {
            hand.transform.position = new Vector3 (leftcup.transform.position.x, cupposition.y+ midcup.transform.localScale.y, leftcup.transform.position.z);
        }
        else if(camera.transform.rotation.y > 3.0f)
        {
            hand.transform.position = new Vector3(rightcup.transform.position.x, cupposition.y+ midcup.transform.localScale.y, rightcup.transform.position.z);
        }
    }
}
