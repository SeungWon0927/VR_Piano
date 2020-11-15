using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestart : MonoBehaviour
{
    public int bugnum = 0;
    public GameObject myprefab;

    public GameObject bug;
    public GameObject table;

    public int check = 0;
    private float interval = 0.5f;
    private float nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Start))
        {
            check = 1;
            
            return;
        }
        if ((check == 1) && (bugnum < 20) && (Time.time > nextTime))
        {
            nextTime = Time.time + interval;
            Makebug();
            Debug.Log(bugnum);
           // gameObject.GetComponent<CharacterController>();
        }
        //Debug.Log(score);
    }
    
    void Makebug()
    {
        
        float xvalue = Random.Range((float)table.transform.position. x - ((table.transform.localScale.x)/2), (float)table.transform.position.x
                + ((table.transform.localScale.x) / 2));
        float zvalue = Random.Range((float)table.transform.position.z - ((table.transform.localScale.z) / 2), (float)table.transform.position.z
                + ((table.transform.localScale.z) / 2));    
        bug = (Object.Instantiate(myprefab));
            bug.transform.position = new Vector3(xvalue, table.transform.position.y + 0.025f, zvalue);
            bug.transform.localScale = new Vector3(0.025f, 0.025f, 0.025f);
       
            bugnum++;

    }
}
