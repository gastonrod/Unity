using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentNumber : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "The current number is: 500";
	}

	// Update is called once per frame
	void Update () {
		text.text = "The current number is: " + NumberWizard.guess;
	}
}
