using UnityEngine;
using System.Collections;

public class ReturnShot_Behavior : MonoBehaviour {
	
	GameObject player;
	Player_Powerup powerupScript;
	public float speed = 10f;
	float lifetime = 5.0f;
	
	public GameObject other;
    public Rigidbody rb;
		
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
		rb = other.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, speed * Time.deltaTime);
	}


	void OnBecameInvisible(){
	//	gameObject.SetActive (false);
	//	Destroy(gameObject);
	
		rb.velocity = -rb.velocity;
		Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), false);
	}


	void Awake()
	{
		Destroy(gameObject, lifetime);
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Obstacle"){
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		
		if(other.name == "Player"){
			Destroy(gameObject);
		}
		
		
	}
}
