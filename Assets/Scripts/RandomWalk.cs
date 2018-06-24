using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float speed=0.001f;

	private Vector3 direction = new Vector3();
	private int t=0;
	public int TIME = 500;
	// Use this for initialization
	void Start () {
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
			float x = Random.Range(-2,2);
			float y = Random.Range(-2,2);
			float z = Random.Range(-2,2);
			direction = speed * new Vector3(x,y,z);
			t=0;
		}
		Vector3 temp = transform.position + direction;
		transform.position = temp;
	}
}
