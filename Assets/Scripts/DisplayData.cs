using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour {

	// Use this for initialization
    public Transform target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text=target.position.ToString();
        this.GetComponent<Text>().text += '\n' + target.eulerAngles.ToString();
	}
}
