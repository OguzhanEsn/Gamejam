using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraDoorScript
{
public class CameraOpenDoor : MonoBehaviour {
	public float DistanceOpen=6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, DistanceOpen)) {
				if (hit.transform.GetComponent<DoorScript.Door> ()) {

				if (Input.GetKeyDown(KeyCode.F))
					hit.transform.GetComponent<DoorScript.Door> ().OpenDoor();
			}else{
				
			}
		}else{
			
		}
	}
}
}
