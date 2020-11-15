using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject teleportTarget;
	public GameObject thePlayer;

	private RaycastHit hit;


	
	public GameObject check()
	{
		//Ray ray = new Ray(thePlayer.transform.position, teleportTarget.transform.position);
		
		
		if (Physics.Raycast(thePlayer.transform.position, teleportTarget.transform.forward, out hit, 100f))
		{
			teleportTarget.transform.position = hit.point;
			return hit.collider.gameObject;
			if (hit.collider.tag == "Ground")
			{
				if (!teleportTarget.activeSelf)
				{
					teleportTarget.SetActive(true);
				}
				
			}
			else { teleportTarget.SetActive(false); }
		}
		else {
			return null;
			teleportTarget.SetActive(false); }
	}
	void Update()
	{
		if (OVRInput.GetDown(OVRInput.Button.One))
		{
			if (check() != null)
			{
				TP();
			}
		}
	}
	void TP()
	{
		
				Vector3 tpposition = teleportTarget.transform.position;
		thePlayer.transform.position = new Vector3(tpposition.x, thePlayer.transform.position.y, tpposition.z);
	
	}

}

