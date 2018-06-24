using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour {
	public float Length=1.0f;
	public float height = 1f;
	public float speed = 1f;
	public Vector2 destination = new Vector2(0f, 1f);
	private Vector3 tempPos;
	private Vector3 originalPos;
	public int state=0;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().useGravity=false;
		tempPos = transform.position;
		originalPos = tempPos;
	}
	// Update is called once per frame
	void Update () {
		if(state==0){
			MoveUpward();
		}else if(state==1){
			MoveX();
		}else if(state==2){
			MoveY();
		}else if(state==3){
			this.GetComponent<Rigidbody>().useGravity=true;
		}
	}

	void MoveUpward(){
		if(tempPos.y < height+originalPos.y){
			tempPos.y += speed*Time.deltaTime;
			transform.position = tempPos;
		}else{
			state=1;
		}
	}

	void MoveX(){
		if(tempPos.x < Length*destination.x+originalPos.x){
			tempPos.x += speed*Time.deltaTime;
			transform.position = tempPos;
		}else{
			state=2;
		}
	}

	void MoveY(){
		if(tempPos.z < Length*destination.y+originalPos.z){
			tempPos.z += speed*Time.deltaTime;
			transform.position = tempPos;
		}else{
			state=3;
		}
	}
}
