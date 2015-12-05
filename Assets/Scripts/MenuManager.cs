using UnityEngine;
using System.Collections;
using AssemblyCSharp;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour {

	public Canvas highestScoreDetailsCanvas;

	private Canvas menuCanvas;

	private MenuController menuController;

	void Awake(){

		menuController = new MenuController ();
		menuCanvas = GetComponent<Canvas> ();

		//set the timescale to zero so initially paused
		Time.timeScale = 0;
	
		highestScoreDetailsCanvas.enabled = false;
	}

	public void PlayGame(){
		menuController.executeAction (this, "play");
		//ToggleMenu ();
	}

	public void QuitGame(){
		menuController.executeAction (this, "quit");
	}

	public void QuitGameMethod(){

		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif

		//Application.ExternalEval("window.close()");
	}

	public void ToggleMenu(){
		//enable or disable canvas
		menuCanvas.enabled = !menuCanvas.enabled;

		//toggle highScoreDetails
		highestScoreDetailsCanvas.enabled = !highestScoreDetailsCanvas.enabled;

		//pause of unpause game
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;  
	}
}
