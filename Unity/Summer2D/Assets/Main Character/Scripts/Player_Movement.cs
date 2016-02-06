using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public float moveSpeed = 5f;
	public float jumpPower = 5f;
	public bool faceRight = true;
	public bool grounded = true;
	public bool attack = false;

	GameObject playerShadow;
	
	// Use this for initialization
	void Start () {
		 playerShadow = GameObject.Find("Player_Shadow");

	}
	
	// Update is called once per frame
	void Update () {

		//Gets horizontal and vertical movement if keys are pressed
		float moveH = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float moveV = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		
		if (Input.GetButton("Jump") && grounded) {
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
			grounded = !grounded;
		}

		//Alters positions of the x and z axis
		transform.position += new Vector3 (moveH, 0, moveV);
		playerShadow.transform.position = new Vector3(transform.position.x, playerShadow.transform.position.y, transform.position.z);		
		
		if (moveH > 0 && faceRight == false)
			FlipSprite ();
		if (moveH < 0 && faceRight == true)
			FlipSprite ();

		if (Input.GetButton("Fire1") && faceRight == true) {
			transform.Rotate(new Vector3(0, 0, -45));
			attack = true;
		}
		
		if (Input.GetButton("Fire1") && faceRight == false) {
			transform.Rotate(new Vector3(0, 0, 45));
			attack = true;
		}
		
		if(!Input.GetButton("Fire1")){
			transform.rotation = Quaternion.identity;
			attack = false;
		}
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Ground")
			grounded = true;
		
		if(collision.gameObject.tag == "Obstacle"){
			grounded = true;
			
			if(attack == true){
				Destroy(collision.gameObject);
			}
		}
		
	}

	void FlipSprite()
	{
		//Switch bool
		faceRight = !faceRight;

		//Flips the sprite's local scale by -1

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;


		}
}
