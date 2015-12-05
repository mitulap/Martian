using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using AssemblyCSharp;

public class RollingCharacterController : MonoBehaviour 
{
	//the number of times we can jump before hitting the ground
	private const int MAX_JUMPS = 2;

	//min time before landing
	private const float LANDED_TIME_LIMIT = 0.8f;

	public int forwardSpeed = 10;
	
	//set the jump force
	public int jumpUpForce = 450;

	//Check if we have jumped
	private bool jump;

	//boolean to check if the character is allowed to jump
	//private bool canJump = true;

	//count how many times we've jumped
	private int numJumps = 0;

	private Rigidbody2D rigidbody2D;

	//Audio
	private AudioSource audio;

	//Sound for Aliend Sound
	public AudioClip alienAudio;
	//private AudioSource alienAudioSrc;

	//Last time it landed
	private float lastLandedTime;


	private SpeedManager speedManager; 
	private float curTime = 0f;

	public static string state = "active";

	void Start(){
		speedManager = new SpeedManager (this);
		InvokeRepeating ("ScoreInc", 1f, 1f);
	}

	void Update(){
		jump = CrossPlatformInputManager.GetButtonDown ("Jump");


	}


	void Awake(){
		rigidbody2D = GetComponent<Rigidbody2D> (); 
		audio = GetComponent<AudioSource> ();
		lastLandedTime = Time.time;
		//alienAudioSrc.clip = alienAudio;
	}

	void FixedUpdate(){
		rigidbody2D.velocity = new Vector2 (forwardSpeed, rigidbody2D.velocity.y);

		if (jump && numJumps < MAX_JUMPS){
			rigidbody2D.AddForce(new Vector2(0, jumpUpForce));
			jump = false;
			numJumps++;
			//animator.SetBool("Ground", false);
		}

	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ("Ground")) {

			//local variable for time
			float currentTime = Time.time;

			//only play the landing sound when jumped long enough time between this and last time landed.
			if(numJumps > 0 || ((currentTime - lastLandedTime) > LANDED_TIME_LIMIT) ){
				//Play Audio
				audio.Play();
			}

			//resetting numJumps and lastLandedTime
			numJumps = 0;
			lastLandedTime = Time.time;
			//animator.SetBool("Ground", true);

		}

		if (collision.gameObject.CompareTag ("alien")) {
			PlayerStateManager.SetState("dead");
			collision.gameObject.GetComponent<AudioSource>().Play();

			//state = "dead";
		}

	}

	private void ScoreInc(){
		curTime += 1;

		if (curTime < 25) {
			if (curTime > 5 && curTime <= 10) {
				speedManager.SetNewSpeed ("low");
			} else if (curTime > 10 && curTime <= 20) {
				speedManager.SetNewSpeed ("medium");
			} else if (curTime > 20) {
				speedManager.SetNewSpeed ("high");
			}
		}

	}
}


