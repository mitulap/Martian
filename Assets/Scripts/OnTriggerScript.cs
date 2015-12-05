using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class OnTriggerScript : MonoBehaviour {

	//private Scorer scorer = new Scorer ();
	//public AudioClip;

	private GameObject audioObject;
	
	void Awake(){
		//Finding GumballSound object
		audioObject = GameObject.Find ("GumballSound");

	}


	void OnTriggerEnter2D(Collider2D collider){
	
		//calling sound
		audioObject.GetComponent<AudioSource> ().Play ();

		gameObject.SetActive (false);

		//print (this.gameObject.name);

		string objectName = this.gameObject.tag;

		Scorer.ScoreAdderForGumballs (objectName);

		//this.gameObject.GetComponent<AudioSource> ().enabled = true;



		//this.gameObject.active = false;
	}
}
