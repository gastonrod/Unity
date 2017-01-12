using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private Ball ball;
	public bool autoPlay;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay){
			AutoPlay();
		} else {
			MoveWithMouse();
		}
	}

	private void AutoPlay(){
		Vector3 pos = new Vector3(ball.rigidbody2D.position.x ,this.transform.position.y, this.transform.position.z);
		this.transform.position = pos;
	}



	private void MoveWithMouse(){
		float width = 1;
		float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.972f, 15.066f);
		Vector3 pos = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.z);
		this.transform.position = pos;
	}
}
