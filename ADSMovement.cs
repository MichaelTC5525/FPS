using UnityEngine;
using System.Collections;

public class ADSMovement : MonoBehaviour {

	public GameObject self;

	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire2"))
        {
            transform.Translate(new Vector3(-0.29, 0.023, -0.32));
        } else
        {
			transform.position = new Vector3(0.3, 0, 0.77);
        }
        
	}
	
}
