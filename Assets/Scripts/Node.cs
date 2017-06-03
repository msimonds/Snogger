using UnityEngine;
using System.Collections;

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

    public void init(Vector2 pos, bool head, Snake sn)
     {
        
        this.head = head;
        this.snake = sn;
        this.stopwatch = 0;
        this.spriteIndex = 0;   
        
        GameObject model = new GameObject();
        model.transform.parent = transform;
        render = model.AddComponent<SpriteRenderer>();
        spritez= Resources.LoadAll<Sprite>("Sprites/cats");
        render.sprite = spritez[0];
        model.transform.localScale = new Vector2(1.849568f, 2.248518f);

        this.body = gameObject.AddComponent<Rigidbody2D>();
        this.body.gravityScale = 0;
        this.body.isKinematic = true;
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        this.coll.size = new Vector2(0.2f, 0.3f);
        if (head)
        {
            coll.isTrigger = true;
        }
        coll.enabled = false;


        this.transform.position = pos;

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        // Food?
        if (coll.tag.Equals("LostCat"))
        {
            // Get longer in next Move call
            snake.ate = true;

            //Remove from list of current LostCats
            snake.CatList.Remove(coll.gameObject.GetComponent<Lost>());

            // Remove the Food
            Destroy(coll.gameObject);
            
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
            render.sprite = spritez[spriteIndex+11];
            stopwatch = 0;
        }
        stopwatch += Time.deltaTime;


    }











}
