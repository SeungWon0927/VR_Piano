using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcol : MonoBehaviour
{
    public BoxCollider my;
    public GameObject table;
    public Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        my = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (table.transform.position != new Vector3(0.0f, 0.0f, 0.0f))
        {
            my.size = new Vector3(table.transform.localScale.x, table.transform.localScale.y, table.transform.localScale.z);
        }
    }
}
