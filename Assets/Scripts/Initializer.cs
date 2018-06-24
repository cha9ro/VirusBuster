using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviour {
	private GameObject ground;
	public GameObject FocusSquare;
	public GameObject ChessWorld;
	public GameObject ChessBoard;
	public GameObject WhitePieces;
	public GameObject BlackPieces;
	public GameObject ToBeDestroyed;
	// Use this for initialization
	void Start () {
		// foreach (Transform child in WhitePieces.transform){
        //     //  print("Foreach loop: " + child);
		// 	child.GetComponent<Rigidbody>().useGravity=false;
		// 	child.GetComponent<Rigidbody>().isKinematic=true;
		// }

		// WhitePieces.SetActive(false);
		// BlackPieces.SetActive(false);
		// ChessBoard.SetActive(false);
		// ChessWorld.SetActive(false);
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		ground = FocusSquare.GetComponent<FocusSquare>().foundSquare;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void TaskOnClick(){
		SyncTransform(ChessWorld, ground);
		Destroy(ToBeDestroyed);
		// SyncTransform(BlackPieces, ground);
		// SyncTransform(WhitePieces, ground);
		// ChessBoard.SetActive(true);
		// BlackPieces.SetActive(true);
		// WhitePieces.SetActive(true);

		// foreach (Transform child in WhitePieces.transform){
        //     //  print("Foreach loop: " + child);
		// 	child.GetComponent<Rigidbody>().velocity = Vector3.zero;
		// 	child.GetComponent<Rigidbody>().useGravity=true;
		// 	// child.GetComponent<Rigidbody>().isKinematic=false;
		// }
	}

	void SyncTransform(GameObject from, GameObject to){
		from.transform.localPosition=to.transform.position;
		from.transform.localRotation=to.transform.rotation;
	}
}
