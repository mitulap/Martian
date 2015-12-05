using UnityEngine;
using System.Collections;

public class QuadScrollScript : MonoBehaviour {

	// Use this for initialization

	public float scrollSpeed;


	void Start () {

	}



	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, 0);

		gameObject.GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);

	}
}
