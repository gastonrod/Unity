using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	bool hasStarted;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		hasStarted = false;
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( !hasStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		if(Input.GetMouseButton(0) && !hasStarted){
			hasStarted = true;
			this.transform.rigidbody2D.velocity = new Vector2( 2f, 10f);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range (0f, 0.2f));

		if (hasStarted){
//			audio.Play();
			transform.rigidbody2D.velocity += tweak;
		}
	}


}
