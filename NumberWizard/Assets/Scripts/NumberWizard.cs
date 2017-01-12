using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		guess = 500;
		printInstructions();
		max = max + 1;
	}
	
	// Update is called once per frame
	void Update () {
		manageInput();
	}
	void manageInput(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			min = guess;
			guess = (max + min) / 2;
			print("Higher or lower than" + guess + "?");
		}else if(Input.GetKeyDown(KeyCode.DownArrow)){
			max = guess;
			guess = (max + min) / 2;
			print("Higher or lower than" + guess + "?");
		}else if(Input.GetKeyDown(KeyCode.Return)){
			print("Wonnered");
			Start();
		}
	}
	void printInstructions(){
		print ("============================");
		print("Welcome to number wizard");
		print("Pick a number in your head but dont tell me:");
		print("The highest number you can pick is " + max);
		print("The lowest number you can pick is " + min );
		print("Is the number higher or lower than " + guess +" ?");
		print("Up arrow for higher, down arrow for lower, enter for equals");
	}
	
}