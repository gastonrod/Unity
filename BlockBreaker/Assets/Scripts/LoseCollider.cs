﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D(Collision2D collision){
		levelManager.LoadLevel("Lose");
	}

	void OnTriggerEnter2D(Collider2D trigger){
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
