using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreSetter : MonoBehaviour {

	private const string HIGH_SCORE_TEXT = "High Score: ";

	private Text text;
	private string highScoreKey;

	void Awake(){
		text = GetComponent<Text> ();

		highScoreKey = Application.loadedLevelName;

		SetHighScoreText ();
	}

	/* Display high score */
	private void SetHighScoreText(){
		int highScore = PlayerPrefs.GetInt (highScoreKey);

		text.text = HIGH_SCORE_TEXT + highScore;
	}

	/*check if the score is a new high score */
	public bool IsNewHighScore(int score){
		bool isNewHighScore = false;

		//the old highest score
		int highScore = PlayerPrefs.GetInt (highScoreKey);
		if (score > highScore) {
			isNewHighScore = true;
		}
		return isNewHighScore;
	}

	/* Set a new high score */
	public void SetNewHighScore(int newHighScore){

		//set the new one
		PlayerPrefs.SetInt (highScoreKey, newHighScore);

		//display it
		text.text = HIGH_SCORE_TEXT + newHighScore;
	}


}
