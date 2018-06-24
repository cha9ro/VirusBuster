using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDissapear : MonoBehaviour {
	public GameObject fire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other)
    {
		Debug.Log("collision");
		if (other.gameObject.transform.localPosition.y > this.transform.localPosition.y)
		{
			
			Instantiate(fire, this.transform);
			// fire.transform.parent = this.gameObject.transform;
			Destroy(this.gameObject);
			DestroyImmediate(fire, true);
		}
     }
}
