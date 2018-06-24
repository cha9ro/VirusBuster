using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach to each piece. Click the button to arrange it to the initial position
public class InitializerPiece : MonoBehaviour {
	public Button button;

	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		
	}
}
