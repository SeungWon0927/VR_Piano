using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public CharacterController controller;
    public GameObject bug;
    public GameObject table;
    public AudioSource source;



    private int count = 0;
    private Text myscore;
    private int end = 1;

    private float xvalue;
    private float zvalue;

    private float speed;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
   {
    
        // myscore = GameObject.Find("Score").GetComponent<Text>();
        speed = 0.1f;
        xvalue = Random.Range(-1.0f, 1.0f);
       
        zvalue = Random.Range(-1.0f, 1.0f);
        if (xvalue == 0.0f && zvalue == 0.0f)
            xvalue = 1.0f;

    }
// Update is called once per frame
    void Update()
    {
        if (table.transform.position != new Vector3(0.0f, 0.0f, 0.0f))
        {
            
            controller = gameObject.GetComponent<CharacterController>();
            direction = new Vector3(xvalue, 0.0f, zvalue);
            
            controller.SimpleMove(direction*speed);

            if(bug.transform.position.x + 0.03f >= table.transform.position.x+(table.transform.localScale.x/2) ||
                bug.transform.position.x - 0.03f <= table.transform.position.x - (table.transform.localScale.x / 2) ||
                bug.transform.position.z + 0.03f >= table.transform.position.z + (table.transform.localScale.z / 2) ||
                    bug.transform.position.z - 0.03f <= table.transform.position.z - (table.transform.localScale.z / 2))
            {
                xvalue *= -1.0f;
                zvalue *= -1.0f;
            }
         

        } 
        
    }

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            source.Play();
            bug.gameObject.SetActive(false);
            //Destroy(this);
            //source.clip = clip;
            
            count++;
        }
    }
    /* void counttext()
    {
        myscore.text = "Score: " + count.ToString();
        if (count >= 20)
        {
            myscore.text = "End";
            end = 1;
        }
    }*/
}
    
