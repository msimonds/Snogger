using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stream : MonoBehaviour {
    //This class can create an instance of a stream where you can define the pattern and the size of the stream

    Snake snake;
    float speed;
    float fireRate=3f;
    int curr;
    float time;
    Vector2 dir;
	// Use this for initialization
	void Start () {
	
	}
    
    //Speed is time in seconds 
    public void init(Snake sn, Vector2 pos, Vector2 dir, float speed, List<float> pattern) 
    {
        this.snake = sn;
        this.dir = dir;
        this.speed = speed;
        this.transform.position = pos;
        SpriteRenderer render = this.gameObject.AddComponent<SpriteRenderer>();
        Sprite[] spritez = Resources.LoadAll<Sprite>("Sprites/Wheel1");
        render.sprite = spritez[0];
        //0 1 2 for small, med, large sized streams will be in the list
        //TODO: Make a model for this object, animations 
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > fireRate)
        {
            //make a Shot object, give it a velocity 
            GameObject g = new GameObject();
            Shot sh = g.AddComponent<Shot>();
            //g.transform.parent = this.transform;            
            sh.init(this, 0f, dir * speed);
            time = 0;
        }

        curr += 1;        
	}

  
}
