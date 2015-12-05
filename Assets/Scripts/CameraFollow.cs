using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//Object the camera should follow
	public Transform followTarget;
	public GameObject quad;
	public GameObject sun;


	private Vector3 newCameraPosition;
	private Vector3 quadPosition;
	private Vector3 sunPos;

	void Update(){
		newCameraPosition = new Vector3 (followTarget.position.x, followTarget.position.y, transform.position.z);
		transform.position = newCameraPosition;

		sunPos = new Vector3 (newCameraPosition.x - 25,newCameraPosition.y + 15,sun.transform.position.z);

		sun.transform.position = sunPos;
		quadPosition = new Vector3 (followTarget.position.x, followTarget.position.y, 5);

		quad.transform.position = quadPosition;
	}

}
