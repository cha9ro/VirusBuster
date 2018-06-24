using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PaintManager : MonoBehaviour {
	private Vector3 previousPosition;
	public GameObject cubeObj;

	void OnEnable(){
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
	}

	void OnDestroy(){
		UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ARFrameUpdated(UnityARCamera aRCamera){
		Vector3 paintPosition = GetCameraPosition(aRCamera) + (Camera.main.transform.forward*0.2f);
		if(Vector3.Distance(paintPosition, previousPosition)>0.025f){
			Instantiate(cubeObj, paintPosition, transform.rotation);
			previousPosition = paintPosition;
		}
	}

	private Vector3 GetCameraPosition(UnityARCamera camera){
		Matrix4x4 matrix = new Matrix4x4();
		matrix.SetColumn(3, camera.worldTransform.column3);
		
		return UnityARMatrixOps.GetPosition(matrix);
	}
}
