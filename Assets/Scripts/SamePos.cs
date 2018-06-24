using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePos : MonoBehaviour {
	public GameObject ground;
	private GameObject plane;
	private Vector3 tempPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// GameObject plane = ground.GetComponent<UnityEngine.XR.iOS.UnityARGeneratePlane>().planePrefab;
		plane = ground.GetComponent<FocusSquare>().foundSquare;
		tempPos = transform.position;
		tempPos.y = plane.transform.position.y;
		transform.position = tempPos;
	}
}
