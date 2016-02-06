using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform follow;
	public Transform barrier1;
	public Transform barrier2;
	public Transform barriery;
	//public float Height;
	public float Zoom = -10.5f;
	private float maxx; //2.9f;
	private float minx;
	public float miny;
	public float height = 1.49f;
	private bool lockx = false;
	private bool locky = false;

	// Use this for initialization
	void Start () {

		//Finds positions of the barriers in order to have the camera stop there
		maxx = barrier1.position.x - 4.7f;
		minx = barrier2.position.x + 4.7f;
		miny = barriery.position.y;

		//Character starts at right-most of the stage, therefore places camera there
		transform.position = new Vector3 (maxx, height, Zoom);

	}
	
	// Update is called once per frame
	void Update () {
		lockx = false;
		locky = false;
		float lockposx = transform.position.x;
		//float lockposy = transform.position.y;

		//Checks the position of the character on the x axis
		if (follow.position.x > minx && follow.position.x < maxx) {
			transform.position = new Vector3 (follow.position.x, height, Zoom);
			lockx = false;
		}
		else {
			//If the camera hits a barrier, then lock the camera from going any further on the x-axis
			lockx = true;
			lockposx = transform.position.x; //Record where the locked position is
		}

		//Checks the position of the character on the y axis
		if (follow.position.y > .814f) {
			transform.position = new Vector3 (follow.position.x, follow.position.y, Zoom);
			locky = false;
		}
		else {
			//If the camera hits a y-axis barrier, lock the y axis
			locky = true;
			//Did not need to record the y-axis since we have the value
		}

		//Checks to see if there is a locked axis and move camera accordingly
		if (lockx == true) {//X-Axis is locked

			if (locky == true) {
				transform.position = new Vector3 (lockposx, height - .67f, Zoom);
			}
			if (locky == false) {
				transform.position = new Vector3 (lockposx, follow.position.y, Zoom);
			}

		} else {//X-Axis is not locked

			if (locky == true) {
				transform.position = new Vector3 (follow.position.x, height - .67f, Zoom);
			}
			if (locky == false) {
				transform.position = new Vector3 (follow.position.x, follow.position.y, Zoom);
			}

		}



	}

}
