using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[RequireComponent(typeof(SteamVR_TrackedObject))]


public class BallSpeed: MonoBehaviour
{


public float speed = 10;
public SteamVR_TrackedObject paddle;
SteamVR_Controller.Device device;

	void FixedUpdate() {
		device = SteamVR_Controller.Input((int)paddle.index);
	}

    // Start is called before the first frame update
    void Start()
    {

		GetComponent<Rigidbody>().velocity = Vector3.forward *speed;
		Debug.Log(paddle.index);
        
    }


    // Update is called once per frame
    void Update()
    {


        
    }

	 void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "BeachBat3"){
			direction = Vector3.Reflect(device.velocity.normalized, other.GetContact(0).normal);
 			GetComponent<Rigidbody>().velocity = direction * speed;
			Debug.Log(device.velocity);
			Debug.Log(other.GetContact(0));
		}
    }	

}
