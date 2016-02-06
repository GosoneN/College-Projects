using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public float movespd = 10f;
	public float jumpHeight = 50;

	public bool grounded = false; //Checks to see if player is on the ground

	// Use this for initialization
	void Start () {
	
	}

	//Does not work
	void OnCollisionEnter(Collider col)
	{
		if (col.GetComponent<Collider>().gameObject.tag == "ground")
			Destroy (col.gameObject);
	}

	//Always updated with the physics engine
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal"); //Movement on the X-axis
		float vertical = Input.GetAxis ("Vertical"); //Movement on the Y-Axis
		bool jump = Input.GetButton ("Jump");

		//Creates a Vector3 since movement is in 3D
		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		transform.position += movement * movespd; //Moves the player

		//Attempt at single jump
		if (jump == true) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jumpHeight, 0));
			grounded = false;
		}


	}

	// Update is called once per frame
	//Sometimes can go out of sync with physics engine
	void Update () {
	
	}
}
