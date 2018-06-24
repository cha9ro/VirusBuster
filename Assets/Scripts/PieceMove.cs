using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceMove : MonoBehaviour, IPointerClickHandler {
	public Vector2 initPos;
	public GameObject Controller;
	public GameObject whitePieces;
	public GameObject blackPieces;
	// public Vector2 desPos;

	// private GameObject selectedPiece;
	private bool isSelected=false;
	private float length = 9f;
	private int N = 8;
	private float height;

	// Use this for initialization
	void Start () {
		Vector2 boardPos = length*initPos -(N/2-0.5f) * length * new Vector2(1,1);
		Vector3 pos = new Vector3(boardPos.x, 7.25f, boardPos.y);
		transform.localPosition = pos;

		isSelected = Controller.GetComponent<ChessControl>().isSelected;
		length = Controller.GetComponent<ChessControl>().length;
		N = Controller.GetComponent<ChessControl>().N;
		height = Controller.GetComponent<ChessControl>().height;
	}
	
	// Update is called once per frame
	void Update () {
		isSelected = Controller.GetComponent<ChessControl>().isSelected;
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		if(isSelected == false){
			//
			Debug.Log(name + " is selected");
			//
			DisableChildrenBoxCollider(whitePieces);
			DisableChildrenBoxCollider(blackPieces);
			//
			isSelected = true;
			Controller.GetComponent<ChessControl>().isSelected = isSelected;
			Controller.GetComponent<ChessControl>().selectedPiece = gameObject;
		}
    } 

	void DisableChildrenBoxCollider(GameObject parent){
		foreach (Transform child in parent.transform){
            //  print("Foreach loop: " + child);
			child.GetComponent<BoxCollider>().enabled=false;
		}
	}
}
