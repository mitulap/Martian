using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;


public class ScoreSetter : MonoBehaviour {

	private const string SCORE_TEXT = "Score: ";

	//Keep track of the score.
	private float floatScore;

	private Text text;

	//time since started playing game
	private float startTime;

	void Awake(){
		//set the startTime
		startTime = Time.time;

		//Set the text
		text = GetComponent<Text> ();
	}

	void Start(){
		InvokeRepeating ("ScoreAdder", 1f, 1f);
	}

	void Update(){
		floatScore = Time.time - startTime;
		int intScore = GetIntScore ();

		//if(Mathf.RoundToInt (floatScore) 

		text.text = SCORE_TEXT + intScore;
	}


	private void ScoreAdder(){
		Scorer.ScoreAdderForTime (1);
	}
	/* Round the score to int */
	public int GetIntScore(){

		return Scorer.GetScore ();
		//return Mathf.RoundToInt (floatScore);
	}

	public void ResetScore(){
		//reset score variable
		floatScore = 0;

		//Setting score
		Scorer.SetScore (0);

		//reset startTime
		startTime = Time.time;
	}

}
