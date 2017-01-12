using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float vel;
	private float xmax ;
	private float xmin ;
	private bool goRight;
	private static float amountOfShips;
	private static LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + width / 2 ;
		xmax = rightMost.x - width / 2 ;
		goRight = true;



		foreach(Transform row in transform){
			foreach(Transform child in row.transform){
				amountOfShips++;
				GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
				enemy.transform.parent = child;
			}
		}
	}
	
	void Update () {
		if(goRight){
			transform.position += Vector3.right * vel * Time.deltaTime;
		} else {
			transform.position += Vector3.left * vel * Time.deltaTime;
		}
		if( transform.position.x < xmin || transform.position.x > xmax){
			goRight = !goRight;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax) , transform.position.y, transform.position.z);
		}
	}
	public static void DestroyShip(){
		amountOfShips--;
		if(amountOfShips <= 0){
			levelManager.LoadLevel("Win");
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

}