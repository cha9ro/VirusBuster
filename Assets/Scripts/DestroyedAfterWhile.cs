using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedAfterWhile : MonoBehaviour {

    float time = 0f;
	float end = 1f;
	void Start () {
	}
    
    // Update is called once per frame
    void Update () {
       time += Time.deltaTime;
        print(time);
        if (time > end)
        {
            Destroy(gameObject);
        }

        
    }
}
