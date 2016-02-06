using UnityEngine;
using System.Collections;


public class Player_Movement : MonoBehaviour {

	public float speed = 0f;

	private bool facingLeft = true;

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3 (0, 0, 9.8f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Fixed Update, which is a better option for the physics engine
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");


		GetComponent<Rigidbody>().velocity = new Vector3 (horizontal * speed, vertical* speed, 0);

		if (facingLeft == true && horizontal > 0)
			Flip ();
		if (facingLeft == false && horizontal < 0)
			Flip ();

	}

	//Will flip the character sprite 180 degrees
	void Flip()
	{
		facingLeft = !facingLeft;

		Vector3 scale = transform.localScale;
		scale.x = -1 * scale.x;
		transform.localScale = scale;
	}
}
