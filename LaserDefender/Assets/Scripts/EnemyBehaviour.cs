using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health;
	public float firingRate;
	public float projectileSpeed;
	public GameObject projectile;


	void Start(){
		InvokeRepeating("Fire", 0.00001f, firingRate);
	}

	void Fire(){
		Vector3 startPos = Vector3.down + transform.position;
		GameObject proj = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
		proj.rigidbody2D.velocity = new Vector3( 0, -projectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		Laser proj = col.gameObject.GetComponent<Laser>();
		if (proj != null){
			EnemySpawner.DestroyShip();
			health -= proj.GetDamage();
			proj.Hit();
			if (health <= 0){
				Destroy(gameObject);
			}
		}
	}
}
