using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterObject : MonoBehaviour {
	public Transform target;
	public float speed=0.001f;

	private Vector3 vToObj = new Vector3();
	private int t=0;
	public int TIME = 500;
	// Use this for initialization
	void Start () {
		vToObj = speed * (target.position-transform.position);
		StartCoroutine(Example5());
	}

	IEnumerator Example5()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(5);
        print(Time.time);
    }
	
	// Update is called once per frame
	void Update () {
		t++;
		if(t>TIME){
			vToObj = speed * (target.position-transform.position);
			transform.LookAt(target);
			t=0;
		}
		Vector3 temp = transform.position + vToObj;
		transform.position = temp;
	}

		IEnumerator Example1()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
    }
}
