using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

    int capacity;
    Snake sn;
    BoxCollider2D coll;
    bool destroy;
    GameObject model;
    public GameObject target;
    SpriteRenderer rend;


	// Use this for initialization
	void Start () {
	
	}
    //Capacity is the number of kittens the basket can hold
    //Target is any object to be destroyed once the basket is full (ie a wall or something)
    public void init(Snake sn, int capacity, Vector2 pos, GameObject target)
    {
        this.capacity = capacity;
        this.sn = sn;
        destroy = false;
        this.target = target;
        //Code for model and animations
       
        rend = this.gameObject.AddComponent<SpriteRenderer>();
        Sprite[] spritez = Resources.LoadAll<Sprite>("Sprites/ADoor 1");
        rend.sprite = spritez[0];
        this.tag = "Basket";
        
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        this.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {

       
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        print(sn.SnakeList.Count + " heres count");
        
        if(sn.SnakeList.Count > capacity && coll.gameObject.tag.Equals("Head"))
        {
            
           
            int size = sn.SnakeList.Count-1;
            
            for(int i=0;i<capacity;i++)
            {
                Node tmp = sn.SnakeList[size-i];
                sn.SnakeList.RemoveAt(size-i);
                Destroy(tmp.gameObject);
            }
            print("rend: " + rend.enabled);
            Destroy(target);
            rend.enabled = false;
            rend.sprite = null;
            print("rend: " + rend.enabled);
            
            Destroy(this.gameObject,0.2f);        
           
            
        }


    }
}
