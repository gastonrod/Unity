using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
	Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log("Quit requested");
	}
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
}
