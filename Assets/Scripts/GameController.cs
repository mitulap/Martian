using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

public class GameController : MonoBehaviour {

	//if  player falls below this heigt the game is over
	private const int GAME_OVER_HEIGHT = -15;

	public Transform character;

	public MenuManager menuManager;

	public Text info;

	public ScoreSetter score;
	public HighScoreSetter highScoreSetter;

	private string initialInfoText;

	//reference to terrain generator
	public TerrainGenerator terrainGen;

	//character's original positions
	private Vector3 characterInitialPosition ;
	
	//create object of GumballCreation class
	public GumballCreationScripts gumballCreate;

	void Awake(){
		characterInitialPosition = character.position;

		initialInfoText = info.text;

		PlayerStateManager.SetState ("active");
	}

	void Update(){
		//if the player's height is below the minimum, bring up menu

		if (character.position.y < GAME_OVER_HEIGHT) {
			//pause
			menuManager.ToggleMenu();
			SetGameInfoText();
			SetHighScore();
			RestartGame();
		}

		/*if(RollingCharacterController.state.Equals("dead")){
			menuManager.ToggleMenu();
			SetGameInfoText();
			SetHighScore();
			RestartGame();

			RollingCharacterController.state = "active";
		}*/

		if(PlayerStateManager.GetState().Equals("dead")){
			menuManager.ToggleMenu();
			SetGameInfoText();
			SetHighScore();
			RestartGame();

			PlayerStateManager.SetState("active");
			//RollingCharacterController.state = "active";
		}
	}


	private void RestartGame(){

		//set character initial position
		character.position = characterInitialPosition;

		//reset the terrain 
		terrainGen.Restart ();

		//reset the score
		score.ResetScore ();

		//reset gumball position
		//if(gumballCreate != null)
		gumballCreate.ResetPosition ();
	
	}

	private void SetGameInfoText(){

		int intScore = score.GetIntScore ();

		//check if it's a new high score
		bool isNewHighScore = highScoreSetter.IsNewHighScore (intScore);

		//start of the info text to set
		string infoText = initialInfoText + "\n\nYour Score is " + intScore + ". ";

		if (isNewHighScore) {
			infoText += "Well Done! This is a new high score.";
		} else {
			infoText += "This isn't a new high score. Rubbish. Maybe you can try again.";
		}

		info.text = infoText;
	}


	/* set a new high score*/
	private void SetHighScore(){
		//get score
		int intScore = score.GetIntScore ();

		//set a new high score if it's a 
		if (highScoreSetter.IsNewHighScore (intScore)) {
			highScoreSetter.SetNewHighScore(intScore);
		}
	}
}
