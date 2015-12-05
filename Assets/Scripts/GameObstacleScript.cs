using UnityEngine;
using System.Collections;

public class GameObstacleScript : MonoBehaviour {

	//Creating Game obstacles
	public GameObject obstacle;
	public GameObject character;


	void Start(){
		InvokeRepeating ("Go", 1f, 1f);
	}

	// Update is called once per frame
	void Update () {
	//	transform.Translate((Vector3.right * (Random.Range(1,10)) )/10);
	}

	void Go(){

		//Object objectname = Instantiate(obstacle,this.transform.position,this.transform.rotation);

		//Destroy (objectname, 20);

	}
}
