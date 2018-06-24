using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardCellAssign : MonoBehaviour, IPointerClickHandler {
	public Vector2 desPos;

	public GameObject Controller;
	private float length = 9f;
	private bool isSelected = false;
	private int N=8;
	private float height=10f;
	// Use this for initialization
	void Start () {
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
		isSelected = Controller.GetComponent<ChessControl>().isSelected;
		if(isSelected){
			// Ray inputRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(inputRay, out hit)) {
				Vector3 temp = (hit.point - transform.position)/0.005f;
				Debug.Log("Original localPos: " + temp);
				desPos = new Vector2((int)(temp.x/length+N/2), (int)(temp.z/length+N/2));
				Debug.Log(desPos);
				isSelected=false;
				Controller.GetComponent<ChessControl>().desPos = desPos;
				Controller.GetComponent<ChessControl>().isSelected = isSelected;
				Controller.GetComponent<ChessControl>().isReadyToMove = true;
			}
		}
    } 
}
