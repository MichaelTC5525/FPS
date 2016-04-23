using UnityEngine;
using System.Collections;

public class CameraFPS : MonoBehaviour {

    //Private variables can only be accessed from within the Behaviour script in the Integrated Development Environment.
    private Vector3 offset;
	float lookHorizontal;
	float lookVertical;

    //Public variables can be altered inside the Unity Editor. 
    public GameObject player;

    // Use this for initialization
    void Start () {
        //Set the distance from the camera to the player as a variable.
        offset = transform.position - player.transform.position;
    }

    // Using LateUpdate ensures the player has moved before updating.
    void LateUpdate () {
        //Change the camera's position according to the player's movement, so it keeps the same place in relation to the player GameObject.
        transform.position = player.transform.position + offset;
		print (transform.rotation);
    }

    // Call the look-around functions in FixedUpdate for a regular interval.
    void FixedUpdate()
    {
		//Call the functions responsible for the camera view movement.
		MouseHorizontal();
		MouseVertical();
		float maxMin = transform.rotation.x;

		maxMin = Mathf.Clamp (lookVertical, -0.5f, 0.5f);
    }

    void MouseHorizontal()
    {
		lookHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, lookHorizontal, Space.World);  //Global y-axis rotation will be level, no matter how high or low the player is looking from.
    }

    void MouseVertical()
    {
		lookVertical = Input.GetAxis ("Mouse Y");
        //Allow rotation on the local x-axis.
        transform.Rotate(Vector3.right, lookVertical, Space.Self);
    }

}
