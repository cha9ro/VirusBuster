using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessControl : MonoBehaviour {
	public bool isSelected = false;
	public bool isReadyToMove=false;
	public float length= 9f;
	public int N=8;
	public float height=10f;
	public float speed;
	public GameObject selectedPiece;
	public Vector2 desPos;
	public GameObject whitePieces;
	public GameObject blackPieces;

	private int movingState = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isReadyToMove){
			//
			EnableChildrenBoxCollider(whitePieces);
			EnableChildrenBoxCollider(blackPieces);
			//
			float originalHeight = selectedPiece.transform.localPosition.y;
			float x = length*(desPos.x - 3.5f);
			float y = length*(desPos.y - 3.5f);
			Vector3 aboveDes = new Vector3(x, height, y);
			Debug.Log("desPos:" + desPos);
			Debug.Log("recalculated localPos: " + aboveDes);
			//
			// selectedPiece.transform.localPosition = Vector3.zero;
			// isReadyToMove = false;
			//

			// selectedPiece.GetComponent<Rigidbody>().useGravity=false;
			if(movingState == 0){
				moveUpward(selectedPiece, originalHeight);
			}else if(movingState == 1){
				moveHorizonal(selectedPiece, aboveDes);
			}else if(movingState == 2){
				moveDownward(selectedPiece, originalHeight);
				// selectedPiece.GetComponent<Rigidbody>().useGravity=true;
			}else if(movingState == 3){
				isReadyToMove = false;
				movingState = 0;
			}
			// move(selectedPiece, originalHeight, aboveDes);
			// isReadyToMove = false;
			// movingState = 0;
		}
	}

	void moveUpward(GameObject target, float originalHeight){
		Vector3 original = target.transform.localPosition;
		while(target.transform.localPosition.y <= originalHeight + height){
			target.transform.localPosition += speed * Vector3.up * Time.deltaTime/10;
		}
		movingState = 1;
	}

	void moveHorizonal(GameObject target, Vector3 aboveDes){
		while(Vector2.SqrMagnitude(aboveDes - target.transform.localPosition)>=0.1f){
			target.transform.localPosition += speed * Vector3.Normalize(aboveDes-target.transform.localPosition) * Time.deltaTime/10;
		}
		movingState = 2;
	}

	void moveDownward(GameObject target, float originalHeight){
		originalHeight = 7.25f;
		while(target.transform.localPosition.y > originalHeight){
			Vector3 temp = target.transform.localPosition;
			target.transform.localPosition += speed * Vector3.down * Time.deltaTime;
		}
		movingState = 3;
	}

	void move(GameObject target, float originalHeight, Vector3 aboveDes){
		Rigidbody rb = target.GetComponent<Rigidbody>();
		rb.velocity = speed * Vector3.up;
		while(target.transform.localPosition.y <= originalHeight + height){
			;;
		}
		rb.velocity = speed * Vector3.Normalize(aboveDes-target.transform.localPosition);
		while(Vector2.SqrMagnitude(aboveDes - target.transform.localPosition)>=0.1f){
			;;
		}
		rb.velocity = speed * Vector3.down;
		while(target.transform.localPosition.y > originalHeight){
			;;
		}
	}
	void EnableChildrenBoxCollider(GameObject parent){
		foreach (Transform child in parent.transform){
            //  print("Foreach loop: " + child);
			child.GetComponent<BoxCollider>().enabled=true;
		}
	}
	// void move(GameObject target){
	// 	float originalHeight = target.transform.localPosition.y;
	// 	float x = length*(desPos.x - N/2 + 1);
	// 	float y = length*(desPos.y - N/2 + 1);
	// 	Vector3 aboveDes = new Vector3(x, height, y);
		
	// 	while(target.transform.localPosition.y < height){
	// 		Vector3 temp = target.transform.localPosition;
	// 		temp += speed * Vector3.up;
	// 		target.transform.localPosition = temp;
	// 	}

	// 	while(Vector2.SqrMagnitude(aboveDes - target.transform.localPosition)!=0){
	// 		Vector3 temp = target.transform.localPosition;
	// 		temp += speed * Vector3.Normalize(aboveDes-temp);
	// 		target.transform.localPosition = temp;
	// 	}

	// 	while(target.transform.localPosition.y > originalHeight){
	// 		Vector3 temp = target.transform.localPosition;
	// 		temp += speed * Vector3.down;
	// 		target.transform.localPosition = temp;
	// 	}
	// }
}
