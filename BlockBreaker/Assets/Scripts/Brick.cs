using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprite;
	public static int amountOfBricks;
	public AudioClip crack;
	public GameObject smoke;


	// Use this for initialization
	void Start () {
		if(this.tag == "Breakable"){
			amountOfBricks++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		bool isBreakable = (this.tag == "Breakable");
//		AudioSource.PlayClipAtPoint( crack, transform.position);
		if (isBreakable)
			HandleHits();
	}
	void HandleHits(){
		int maxHits = hitSprite.Length + 1;
		timesHit++;
		if(timesHit >= maxHits){
			Destroy (gameObject);
			amountOfBricks--;
			GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			if (amountOfBricks == 0){
				levelManager.LoadNextLevel();
			}
		} else {
			LoadSprites();
		}
	}

	private void LoadSprites(){
		int index = timesHit  - 1;
		if (hitSprite[index] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprite[index];
		} else {
			Debug.LogError("Sprite missing");
		}
	}
}
