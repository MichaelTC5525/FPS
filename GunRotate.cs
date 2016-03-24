using UnityEngine;
using System.Collections;

public class GunRotate : MonoBehaviour {

    //Public variables can be altered inside the Unity Editor.
    public GameObject self;

    // Use this for initialization
    void FixedUpdate()
    {
        Perspective();
    }
	
    // Update is called once per frame
    void Perspective() {
        MouseHorizontal();
        MouseVertical();
    }

    void MouseHorizontal()
    {
        float lookHorizontal = Input.GetAxis("Mouse X");
        self.transform.Rotate(Vector3.up, lookHorizontal, Space.World);
    }

    void MouseVertical()
    {
        float lookVertical = Input.GetAxis("Mouse Y");
		self.transform.Rotate (Vector3.right, lookVertical, Space.Self);
    }
}
