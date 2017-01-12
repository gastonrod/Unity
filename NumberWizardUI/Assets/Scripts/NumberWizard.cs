using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	static public int guess;
	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		guess = 500;
		printInstructions();
		max = max + 1;
	}

	public void Higher(){
		min = guess;
		guess = (max + min) / 2;
		print("Higher or lower than" + guess + "?");
	}

	public void Lower(){
		max = guess;
		guess = (max + min) / 2;
		print("Higher or lower than" + guess + "?");
	}

	public void Win(){
		print("Wonnered");
		Start();
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