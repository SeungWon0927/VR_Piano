using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hand : MonoBehaviour
{
    public AudioSource source;
    private int count = 0;
    public Text myscore;
    private int end = 0;
    // Start is called before the first frame update
    void Start()
    {
        //counttext();
    }

    // Update is called once per frame
    void Update()
    {
       if(end == 0)
        {
          //counttext();
        }
    }
    
    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bugs")
        {
            source.Play();
            other.gameObject.SetActive(false);
           // Destroy(other);
            //source.clip = clip;

            count++;
        }
    }*/
    void counttext()
    {
        myscore.text = "Score: " + count.ToString();
        if(count >= 20)
        {
            myscore.text = "End";
            end = 1;
        }
    }
}
