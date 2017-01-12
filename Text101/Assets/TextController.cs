using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextController : MonoBehaviour {
	public Text text;
	private enum States {celda, espejo, sabanas_0, cerradura_0, celda_espejo, sabanas_1, cerradura_1, libertad};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.celda;
		text.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.celda){
			state_cell();
		} else if(myState == States.sabanas_0){

		} else if(myState == States.espejo){

		}
	}

	void state_cell(){
		text.text = "Te despertas en una celda, lo unico que hay es " +
			" un espejo roto, unas sabanas en el suelo y la puerta" + 
				" de la prision. \n\n" +
				"Persiona V para ver las sabanas\n" +
				"Presiona B para ver el espejo\n" +
				"Presiona N para ver  la cerradura\n";
	}

}
