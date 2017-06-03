using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
    public SwitchDoor target;
	// Use this for initialization
	void Start () {
	    
	}

    
	//Needs a door to remove when it is hit
    //need to add model and a collider to it

	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        Destroy(target.gameObject);
        
    }
}
