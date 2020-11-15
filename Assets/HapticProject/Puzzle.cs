using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;

    public GameObject text;
    void Start()
    {
        text.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
        float vec1;
        vec1 = 0.05f;
        float dis1 = Vector3.Distance(frame1.transform.position, frame2.transform.position);
        float dis2 = Vector3.Distance(frame1.transform.position, frame3.transform.position);
        float dis3 = Vector3.Distance(frame1.transform.position, frame4.transform.position);
        float dis4 = Vector3.Distance(frame2.transform.position, frame3.transform.position);
        float dis5 = Vector3.Distance(frame2.transform.position, frame4.transform.position);
        float dis6 = Vector3.Distance(frame3.transform.position, frame4.transform.position);
        if ((dis1 <= vec1) && (dis2 <= vec1) && (dis3 <= vec1) && (dis4 <= vec1) && (dis5 <= vec1) && (dis6 <= vec1))
        {
            text.SetActive(true);
        }
      
    }
}
