using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour {


    
    float stopwatch;
    public bool head;
    public bool isCat;
    public bool isNew;
    private float COOL = 1.0f;
    float speed;
    Snake snake;
    Rigidbody2D body;
    BoxCollider2D coll;
    Sprite[] spritez;
    SpriteRenderer render;
    int spriteIndex;
    int spriteStart;
    int direction;
    Dictionary<Vector2, int> spriteStartMap;
    Dictionary<Vector2, int> spriteMap;

    public void init(Vector2 pos, bool head, Snake sn)
     {
        
        this.head = head;
        this.snake = sn;
        this.stopwatch = 0;
        this.spriteIndex = 0;
       
        //need to make a map of sprites where each direction maps to a sprite
        GameObject model = new GameObject();
        model.transform.parent = transform;
        render = model.AddComponent<SpriteRenderer>();
        render.sortingLayerName = "Foreground";
        spritez= Resources.LoadAll<Sprite>("Sprites/cats");
        render.sprite = spritez[0];
        model.transform.localScale = new Vector2(1.849568f, 2.248518f);
        render.sortingLayerName = "Midground";
        this.body = gameObject.AddComponent<Rigidbody2D>();
        this.body.gravityScale = 0;
        this.body.isKinematic = true;
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        this.coll.size = new Vector2(0.2f, 0.3f);
        if (head)
        {
            coll.isTrigger = true;
            spriteStart = 0;
        }
        else {
            spriteStart = 44;
        }
        coll.enabled = false;
        this.transform.position = pos;        
        
        spriteStartMap = new Dictionary<Vector2, int>();
        spriteStartMap.Add(Vector2.up, 33);
        spriteStartMap.Add(Vector2.down, 0);
        spriteStartMap.Add(Vector2.left, 11);
        spriteStartMap.Add(Vector2.right, 22);

        spriteMap = new Dictionary<Vector2, int>();
        spriteMap.Add(Vector2.up, 77);
        spriteMap.Add(Vector2.down, 44);
        spriteMap.Add(Vector2.left, 55);
        spriteMap.Add(Vector2.right,66 );

    }

    public void moveNode(Vector2 prevDir, Vector2 pos)
    {
        if (head)
        {
            this.gameObject.transform.Translate(prevDir);
            spriteStart = spriteStartMap[prevDir];//uses the spritestartmap for the Head cat
            render.sprite = spritez[spriteStart];
        }
        else
        {
            transform.position = pos;
            spriteStart = spriteMap[prevDir];
            render.sprite = spritez[spriteStart];
        }     

    }

    //this method will change the sprite based on the direction

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        // Food?
        if (coll.tag.Equals("LostCat"))
        {
            // Get longer in next Move call
            snake.ate = true;

            //Remove from list of current LostCats
            snake.CatList.Remove(coll.gameObject.GetComponent<Lost>());               
        }
        else if (coll.tag.Equals("Switch"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.tag.Equals("Basket"))
        {
            //Just ignore this case for now
            
        }
        // Collided with Tail or Border
        else
        {
            Destroy(snake.gameObject);
        }
        
    }
    

    public void Update()
    {
        if (stopwatch >= COOL && !coll.enabled)
        {
            coll.enabled = true;
        }
      
       if (stopwatch >= 0.05f && stopwatch>=COOL)
        {
            spriteIndex =(spriteIndex+ 1) %3;
            render.sprite = spritez[spriteIndex+spriteStart];
            stopwatch = 0;
        }
        stopwatch += Time.deltaTime;
    }











}
