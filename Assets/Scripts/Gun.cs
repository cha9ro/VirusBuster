using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float speed = 100000;
    public float end = 10000;
    float time = 0f;

	public AudioClip AudioClip1;
	AudioSource bang;

	public Button yourButton, btn;
    private bool sw=false;
	void Start () {
		bang = gameObject.AddComponent<AudioSource>();
		bang.clip = AudioClip1;
		btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		time=0;
	}

	void TaskOnClick(){
		// Debug.Log ("You have clicked the button!");
		sw=true;
	}


    
    // Update is called once per frame
    void Update () {
		btn.onClick.AddListener(TaskOnClick);
        if (sw) {
			Debug.Log("sw=true");

			bang.Play();
            GameObject bullets = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody bulletbody = bullets.GetComponent<Rigidbody>();
			bullets.AddComponent<Rigidbody>();
			bullets.AddComponent<Collider>();
            bulletbody.AddForce(transform.forward * speed);
			Debug.Log("launched");
            sw = false;
        }
        
    }
}
