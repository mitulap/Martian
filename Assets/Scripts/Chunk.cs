using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour {

	//number of ground pieces in a chunk
	public const int CHUNK_SIZE = 20;

	private const int MIN_GAP_SIZE = 0;
	private const int MAX_GAP_SIZE = 0;
	private const int MIN_GAP_POSITION = 0;
	private const int MAX_GAP_POSITION = CHUNK_SIZE - MAX_GAP_SIZE;

	private const int HEIGHT_LOWER_BOUND = 0;
	private const int HEIGHT_UPPER_BOUND = 0;

	private const int RANDOM_HEIGHT_CLAMP_VAL = 14;

	public GameObject groundPrefab;

	private int gapEndPosition;

	//for obstacle
	public GameObject obstacle;
	
	//property
	public float WidthGroundPrefab
	{ get; private set; }

	void Awake(){
		//Set the width of the image
		SpriteRenderer rend = groundPrefab.GetComponent<SpriteRenderer> ();
		WidthGroundPrefab = rend.bounds.size.x;

		InitializeChunk();
	}


	public void RepositionChunk(Vector3 newPosition){
		transform.position = newPosition;

		
	}

	//Initializes the pieces of groung that make up the chunk
	public void InitializeChunk(){

		//int []obstaclePosArr = {2, 8, 12, 19 };
		int []obstaclePosArr = {12 };

		for (int i = 0; i<CHUNK_SIZE; i++) {
			//init


			for(int j = 0; j< obstaclePosArr.Length; j++){

				if(i == obstaclePosArr[j]){
					GameObject obstacleNew = GameObject.Instantiate(obstacle) as GameObject;
					obstacleNew.transform.parent = transform;
					Vector3 obstaclePos = new Vector3(transform.position.x + (i * WidthGroundPrefab) , transform.position.y + 3, transform.position.z);
					obstacleNew.transform.position = obstaclePos;
				}

			}

			GameObject groundPiece = GameObject.Instantiate(groundPrefab) as GameObject;
			
			groundPiece.transform.parent = transform;

			Vector3 piecePosition = new Vector3(transform.position.x + (i * WidthGroundPrefab) , transform.position.y, transform.position.z);



			groundPiece.transform.position = piecePosition;
		}
	}

	public void CreateGaps(){
		int numGroundToDeactivate = Random.Range (MIN_GAP_SIZE, MAX_GAP_SIZE);
		int deactivatePosition = Random.Range (MIN_GAP_POSITION, MAX_GAP_POSITION);

		gapEndPosition = numGroundToDeactivate + deactivatePosition;

		for (int i = 0; i < CHUNK_SIZE; i++) {
			//get the ith child
			Transform child = transform.GetChild(i);

			//set the child to be active to remove previous gaps
			child.gameObject.SetActive(true);

			//create a gap if it should be a gap
			if(IsGap(i, deactivatePosition)){
				child.gameObject.SetActive(false);
			}
		}

	}

	private bool IsGap(int childIndex, int deactivatePosition){
		bool isGap = childIndex >= deactivatePosition && childIndex < gapEndPosition;

		return isGap;
	}

	public int RandomizeSection(int currentRandomHeight){

		//first create gap
		CreateGaps ();

		//then randomize height
		int nextRandomHeight = RndomizeSectionHeight (currentRandomHeight);

		return nextRandomHeight;
	}

	//Rnadomize the height of a section 
	private int RndomizeSectionHeight(int currentRandomHeight){

		int nextRandomHeight = GetRandomSectionHeight (currentRandomHeight);


		for (int i=0; i < CHUNK_SIZE; i++) {
			//get the ith child
			Transform child = transform.GetChild(i);



			//if the child's position is before the end of the gap, set it to current random height
			if( i< gapEndPosition){
				SetChildHeight(child, currentRandomHeight);
			}

			//when reach the end of the gap, use the next random height instead
			else{
				SetChildHeight(child, nextRandomHeight);
			}

		}

		return nextRandomHeight;
	}

	private void SetChildHeight(Transform child, int yPos){

			Vector3 newPosition = new Vector3 (child.position.x, yPos, child.position.z);
			child.position = newPosition;


	}

	//Randomize the height of a section of pieces
	private int GetRandomSectionHeight(int currentRandomHeight){

		int sign = 1;

		if (Random.value > 0.5) {
			sign = -1;
		}

		int nextRandomHeight = currentRandomHeight + sign * Random.Range (HEIGHT_LOWER_BOUND, HEIGHT_UPPER_BOUND);

		//clamp the values to make sure it doesn't go too high up/down. This means we can use a constant value to check if the game's over.
		nextRandomHeight = Mathf.Clamp (nextRandomHeight, -RANDOM_HEIGHT_CLAMP_VAL, RANDOM_HEIGHT_CLAMP_VAL);


		return nextRandomHeight;

	}


	public void ResetChildPosition (){

		for (int i=0; i < CHUNK_SIZE; i++) {
			//get the ith child

			Transform child = transform.GetChild (i);

			if(i == 12){
				Vector3 newPosition = new Vector3 (child.position.x, 3f, child.position.z);
				child.position = newPosition;

			}else{
				//reset the height to zero
				SetChildHeight(child, 0);

			}
		}

	}

}
