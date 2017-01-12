using UnityEngine;
using System.Collections;


public class SpaceShip : MonoBehaviour {
	public float vel;
	public float projectileSpeed;
	public float firingRate;
	public GameObject projectile;
	public float health;


	private LevelManager levelManager;
	private float padding = 1f;
	private float xmax;
	private float xmin;



	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
		InvokeRepeating("Fire", 0.00001f, firingRate);

	}
	// Update is called once per frame
	void Update () {
		if( Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * vel * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * vel * Time.deltaTime;
		}
/*		if( Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.00001f, firingRate);
		} else if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke ("Fire");
		}
*/
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax) , transform.position.y, transform.position.z);
	}

	void Fire(){
		Vector3 startPos = Vector3.up + transform.position;
		GameObject proj = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
		proj.rigidbody2D.velocity = new Vector3( 0, projectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		Laser laser = col.gameObject.GetComponent<Laser>();
		health -= laser.GetDamage();
		laser.Hit();
		if (health <= 0){
			levelManager.LoadLevel("Lose");
		}
	}


}
