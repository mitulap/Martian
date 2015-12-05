using UnityEngine;
using System.Collections;

public class GumballCreationScripts : MonoBehaviour {


	public GameObject blue, green, red, yellow, pink, purple, star;

	public Transform target;
	//Camera camera;

	private Vector3 newCameraPosition;
	

	private float lastBallPos = 0;

	private const int STARTING_POS_OF_GUMBALL = 50;

	GumballCreationFactory gumballCreationFactory;


	void Start(){


		ResetPosition ();
		//camera = GetComponent<Camera>();

		InvokeRepeating ("UpdateGumballPosition", 2f, 1f);

	}


	//Awake method to initialize the balls
	void Awake(){
		gumballCreationFactory = gameObject.GetComponent<GumballCreationFactory> ();
		
		print (gumballCreationFactory);
		InitializeGumBalls ();

	}

	void Update(){



	}

	//Initialize Gumball
	private void InitializeGumBalls(){

		lastBallPos = gumballCreationFactory.CreateGumballs();

		//Implement decorator pattern
		/*for (int i=0; i< 16; i++) {

			switch(Random.Range(1,5)){

			//1 - for Blue
			case 1:
				createGumball(blue);
				break;
			//1 - for Green
			case 2:
				createGumball(green);
				break;
			//1 - for Red
			case 3:
				createGumball(red);
				break;
			//1 - for Yellow
			case 4:
				createGumball(yellow);
				break;
			default:
				break;
			}

		}*/

	}

	private void createGumball(GameObject ball){

		GameObject ballObject = GameObject.Instantiate(ball) as GameObject;
		ballObject.transform.parent = transform;

		//logic to place balls
		if (lastBallPos == 0) {
			lastBallPos = target.position.x + 50;
		} else {
			lastBallPos += Random.Range(20,40) + (float) Random.Range (1, 6);
		}

		Vector3 ballPos = new Vector3(lastBallPos , Random.Range(4, 18), transform.position.z);
		ballObject.transform.position = ballPos;

	}

	private void UpdateGumballPosition(){

		for (int i = 0; i < 16; i++) {
			Transform child = transform.GetChild(i);

			//if(renderer.isVisible == false && (child.position.x < target.position.x ) )
			if(child.position.x < target.position.x - 50 )
			{
				if(!child.gameObject.activeSelf){
					child.gameObject.SetActive(true);
				}
				
				lastBallPos += Random.Range(20,40) + (float) Random.Range (1, 6);
				Vector3 newPosition = new Vector3 (lastBallPos, Random.Range(4, 18), child.position.z);
				child.position = newPosition;
			}
		}

	}

	public void Restart(){
		ResetPosition ();
	}

	public void ResetPosition(){

		lastBallPos = 5.23f + 50;
		for (int i = 0; i < 16; i++) {
			Transform child = transform.GetChild(i);

			if (lastBallPos == 0) {
				lastBallPos = target.position.x + 50;
			} else {
				lastBallPos += 20 + (float) Random.Range (1, 6);
			}

			Vector3 newPosition = new Vector3 (lastBallPos, Random.Range(4, 18), child.position.z);
			child.position = newPosition;

			
		}

	}

	//void Update(){

		//Vector3 screenPos = camera.WorldToScreenPoint (target.position);
		//print ("target is " + screenPos + " pixels from the left");

		//newCameraPosition = new Vector3 (target.position.x, target.position.y, transform.position.z);
		//transform.position = newCameraPosition;

		//print (target.position);
	//}
}


