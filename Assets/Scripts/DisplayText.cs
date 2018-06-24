using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayText : MonoBehaviour {

	public GameObject controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int score = controller.GetComponent<Controller>().score;
		this.GetComponent<Text>().text=score.ToString();
	}
}
