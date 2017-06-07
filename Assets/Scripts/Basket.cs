using UnityEngine;
using System.Collections.Generic;

public class Basket : MonoBehaviour {

    int capacity;
    Snake sn;
    BoxCollider2D coll;
    bool destroy;
    GameObject model;
    public List<GameObject> target;
    SpriteRenderer rend;


	// Use this for initialization
	void Start () {
	
	}
    //Capacity is the number of kittens the basket can hold
    //Target is a list of objects to be destroyed once the basket is full (ie a wall or something)
    public void init(Snake sn, int capacity, Vector2 pos, List<GameObject> target)
    {
        this.capacity = capacity;
        this.sn = sn;
        destroy = false;
        this.target = target;
        //Code for model and animations
       
        rend = this.gameObject.AddComponent<SpriteRenderer>();
        Sprite[] spritez = Resources.LoadAll<Sprite>("Sprites/basket");
        rend.sprite = spritez[0];
        rend.sortingLayerName = "Foreground";
        this.tag = "Basket";
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.2f, 1.2f, 1));

        this.coll = gameObject.AddComponent<BoxCollider2D>();
        this.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {

       
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        
       
        
        if(sn.SnakeList.Count > capacity && coll.gameObject.tag.Equals("Head"))
        {
            
           
            int size = sn.SnakeList.Count-1;
            
            for(int i=0;i<capacity;i++)
            {
                Node tmp = sn.SnakeList[size-i];
                sn.SnakeList.RemoveAt(size-i);
                Destroy(tmp.gameObject);
            }
            sn.lv.setEvent();
            foreach( GameObject obj in target){
                foreach(Transform child in obj.transform) //destroy all the children of the targets
                {
                    Destroy(child.gameObject);
                }
                Destroy(obj);
            }     
            
            
            Destroy(this.gameObject,0.2f);        
           
            
        }


    }
}
