using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour {

    //Private variables can only be accessed from within the Behaviour script in the Integrated Development Environment.
    private LineRenderer gunLine;
    private AudioSource gunSound;
    private Light gunLight;
    private float timer;
    private int bulletsInMag;
    private int bulletsReserve;
	private int bulletsMagUsed;
	private Ray shootRay;

    //Public variables can be altered inside the Unity Editor.
    public float timePerShot = 0.15f;
    public float effectsDisplay = 0.2f;
    public Text bulletsText;
	public float gunRange = 50f;

    GunReload gunReload;

    void Awake()
    {
        //Set references to all required components of the GunBarrelEnd gameobject for visual effect creation.
        gunLight = GetComponent<Light>();
        gunSound = GetComponent<AudioSource>();
        gunLine = GetComponent<LineRenderer>();
    }

    void Start()
    {
		//Set all variables for weapon ammunition caches.
        bulletsInMag = 21;
		bulletsMagUsed = 0;
        bulletsReserve = 315;
        SetBulletsText();
    }

    void Update()
    {
        //Have the timer count by real-time seconds.
        timer += Time.deltaTime;

        //Read input from the computer mouse and have a delay between possible shooting times.
        if (Input.GetButtonDown("Fire1") && timer >= timePerShot)
        { 
        //Send a message to myself so I know it's working.
        Debug.Log("Fire1");
        
        //Call the function to make the shooting effects.
        Shoot();
        }

        //If the timer has exceeded the amount of time the shooting visual effects should be on, turn them off.
        if (timer >= timePerShot * effectsDisplay)
        {
            Debug.Log("End Shot");

            //Call the function needed to deactivate the visual effects.
            Disable();
        }

		if (bulletsInMag == 0) {
			//Reload();
			bulletsInMag = 21;
			bulletsReserve -= 21;
			SetBulletsText ();
			/*if (bulletsReserve == 0)
            {
                Shoot().enabled = false;
            }*/
		} else if (Input.GetKeyDown (KeyCode.R)) {
			Debug.Log ("Reloading...");
			bulletsInMag = 21;
			bulletsReserve -= bulletsMagUsed;
			bulletsMagUsed = 0;
			SetBulletsText ();
		}
    }

    void Shoot()
    {
        //Reset the timer from however long the game has been running since the last fired shot.
        timer = 0.0f;

		//Magazine decreases in capacity.
        bulletsInMag -= 1;

		//Track number of bullets used up from the current magazine.
		bulletsMagUsed += 1;

		//Call the function to update the User Interface for the player to acknowledge the use of a bullet.
        SetBulletsText();

        //Play the gun audio when the bullet fires.
        gunSound.Play();
        Debug.Log("On");

        //Using the gunLight variable set to the Light component attached to the GunBarrelEnd object, the Light turns on.
        gunLight.enabled = true;

		//The Line Renderer draws a line from the GunBarrelEnd.
		gunLine.enabled = true;

		//The Line Renderer starts drawing from the position of the GunBarrelEnd.
		gunLine.SetPosition (0, transform.position);

		//The Line, or Ray, goes in a direction forwards in relation to the object's axes.
		shootRay.direction = transform.forward;

		//The Ray begins where the GunBarrelEnd is.
		shootRay.origin = transform.position;

		//The other end of the line is drawn to the extent of the weapon's range.
		gunLine.SetPosition (1, shootRay.origin + shootRay.direction * gunRange);
    }

    void Disable()
    {
        //Using the gunLight variable set to the Light component attached to the GunBarrelEnd object, the Light turns off.
        gunLight.enabled = false;

		gunLine.enabled = false;
    }

	//Declare the full method for all instances of need to change the User Interface bullet count.
    void SetBulletsText()
    {
			//Create the text to be displayed on-screen for the player to view at any time.
        bulletsText.text = bulletsInMag + " / " + bulletsReserve;
    }

	/*IEnumerator Reload()
    {
		Shoot ().enabled = true;
            bulletsInMag = 21;
            bulletsReserve -= 21;
            yield return new WaitForSeconds(3);
            SetBulletsText();
		Shoot ().enabled = true;
    }*/
}
