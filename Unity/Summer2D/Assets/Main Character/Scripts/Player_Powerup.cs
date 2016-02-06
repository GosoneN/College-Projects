using UnityEngine;
using System.Collections;

public class Player_Powerup : MonoBehaviour {
	
	GameObject playerShadow;
	Player_Movement movementScript;
	public Rigidbody projectile;
	public Rigidbody bouncyShot;
	public Rigidbody returnShot;
	Rigidbody clone;
	bool getShoot = false;
	bool getBouncyShoot = false;
	bool getReturnShoot = false;
	float shootCD = 1.0f;
	float bouncyShootCD = 1.0f;
	float returnShootCD = 1.0f;
	float timeStamp;
	float defaultMoveSpd;
	float defaultJumpSpd;
	
	void Start () {
		 playerShadow = GameObject.Find("Player_Shadow");
		 movementScript = GetComponent<Player_Movement>();
		 timeStamp = Time.time;
		defaultMoveSpd = movementScript.moveSpeed;
		defaultJumpSpd = movementScript.jumpPower;
	}		

/*
	Test code

	void OnTriggerEnter(Collider other) {
		 
		if (other.name == "Powerup_Grow") {
			transform.localScale = new Vector3(2, 2, 2);
			playerShadow.transform.localScale = new Vector3(1, 2, 2);
			
		}
		 
		if (other.name == "Powerup_Speed") {
			movementScript.moveSpeed *= 10;
			
		}
		
		if (other.name == "Powerup_Jump") {
			movementScript.jumpPower *= 2;
			
		}
		 
		other.gameObject.SetActive (false);

	}
*/

	void OnTriggerStay(Collider other) {
		if (Input.GetButton("Fire2") && other.tag == "Powerup") {
			
			// Reset powerup
			movementScript.moveSpeed = defaultMoveSpd;
			movementScript.jumpPower = defaultJumpSpd;
			/*
			transform.localScale = new Vector3(1, 1, 1);
			playerShadow.transform.localScale = new Vector3(0.5f, 1, 1);
			*/

			getShoot = false;
			getBouncyShoot = false;
			getReturnShoot = false;
		
			if (other.name == "Powerup_Grow" && movementScript.faceRight == true) {
				transform.localScale = new Vector3(2, 2, 2);
				playerShadow.transform.localScale = new Vector3(1, 2, 2);
			}
			
			if (other.name == "Powerup_Grow" && movementScript.faceRight == false) {
				transform.localScale = new Vector3(2, 2, 2);
				playerShadow.transform.localScale = new Vector3(1, 2, 2);
			}
			 
			if (other.name == "Powerup_Speed") {
				movementScript.moveSpeed *= 4;
				
			}
			
			if (other.name == "Powerup_Jump") {
				movementScript.jumpPower *= 2;
				
			}
			
			if(other.name == "Powerup_Shoot"){
				getShoot = true;
			}
			
			if(other.name == "Powerup_BouncyShoot"){
				getBouncyShoot = true;
			}
			
			if(other.name == "Powerup_ReturnShoot"){
				getReturnShoot = true;
			}
			
		//	other.gameObject.SetActive (false);
			Destroy(other.gameObject);
		}
		
	}

	void Update(){
		if(timeStamp <= Time.time){			
			if (Input.GetButton("Fire2")){
				if(getShoot == true){
					timeStamp = Time.time + shootCD;
				
					clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
					if(movementScript.faceRight){
						clone.AddForce(500f, 0, 0);
					}
					else{
						clone.AddForce(-500f, 0, 0);
					}
				
				}		
				
				if(getBouncyShoot == true){
					timeStamp = Time.time + bouncyShootCD;
				
					clone = Instantiate(bouncyShot, transform.position, transform.rotation) as Rigidbody;
					if(movementScript.faceRight){
						clone.AddForce(100f, 500f, 0);
					}
					else{
						clone.AddForce(-100f, 500f, 0);
					}
				
				}		
				
				if(getReturnShoot == true){
					timeStamp = Time.time + returnShootCD;
				
					clone = Instantiate(returnShot, transform.position, Quaternion.Euler(90, 0, 0)) as Rigidbody;
					if(movementScript.faceRight){
						clone.AddForce(500f, 0, 0);
					}
					else{
						clone.AddForce(-500f, 0, 0);
					}
				}
			}	
		}
	}
	
}