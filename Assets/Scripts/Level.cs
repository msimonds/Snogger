using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
    public Snake sn;
	// Use this for initialization
	void Start () {
	
	}

    public void init(Snake sn)
    {
        this.sn = sn;

    }

    public virtual void setup()
    {

    }

    public virtual void setEvent()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
