using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Private variables can only be accessed from within the Behaviour script in the Integrated Development Environment.
    private CharacterController controller;
    private Vector3 direction = Vector3.zero;

    //Public variables can be altered inside the Unity Editor. 
    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;




    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController> ();
    }
	
    // The Update method can vary in times between processing, so the FixedUpdate method is more consistent and a better choice to use for these movements.
    // FixedUpdate is called before any Physics calculations, and on a regular time interval.
    void FixedUpdate () {
        if (controller.isGrounded) {
        direction = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
        direction = transform.TransformDirection (direction);
        direction *= speed;
            if (Input.GetButtonDown ("Jump")) {
                    direction.y = jumpSpeed;
            }
        }
        direction.y -= gravity * Time.deltaTime;
        controller.Move (direction * Time.deltaTime);
        float movementHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, movementHorizontal);
    }


}
