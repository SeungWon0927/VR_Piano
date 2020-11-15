using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject cube;
	public GameObject handposition;

	public int check1 = 0;
	public int check2 = 0;
	public Vector3 now;
	public Vector3 max;

    // Start is called before the first frame update
	// Update is called once per frame

	void Update()
	{
		if (OVRInput.GetDown(OVRInput.Button.One))
		{
			
			now = handposition.transform.position;
			check1 = 1;
			return;
			
		}
		else if (OVRInput.GetDown(OVRInput.Button.Two))
		{
			max = handposition.transform.position;
			check2 = 1;
			
			if (check1 != 0 && check2 != 0)
			{
				cube.transform.position = new Vector3((max.x + now.x) / 2, ((max.y + now.y)/2), ((max.z + now.z) / 2));
				cube.transform.localScale = new Vector3(1.0f*(max.x - now.x), 1.0f*(max.y - now.y), 1.0f *(max.z - now.z));
			
				check1 = 0;
				check2 = 0;
			}
		}
	}
}
