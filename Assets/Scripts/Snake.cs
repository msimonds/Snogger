using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Snake : MonoBehaviour {   
    
    private Vector2 direction;
    Vector2 prevDir;
    public List<Node> SnakeList;
    public List<Lost> CatList;
    public int lvNum;
    public Level lv;
 
    float time;
    public bool ate;
    public float fr=0.42f;
    Node head;

    // Use this for initialization
    void Start () {
        
        //TODO: need to overhaul movement mechanics

       
        
        //each level will  consist of :
        //      -the saved unity editor level (with a static resources in it, Snake script with level set correctly)
        //      -the script that controls the dynamic resources of a level
        //Need large overarching game menu to load the unity editor levels      

        Physics2D.gravity = Vector2.zero;
        direction = Vector2.up;
        ate = false;
        Vector2 start = new Vector2(0, 0);
        Vector2 k1 = new Vector2(5, 5);
        Vector2 k2 = new Vector2(-5, -5);
        GameObject headObject = new GameObject();
        headObject.tag = "Head";
        head = headObject.AddComponent<Node>();
        SnakeList = new List<Node>();
        CatList = new List<Lost>();
        SnakeList.Add(head);
        head.init(start, true, this);
        //GameObject spawnerOb = new GameObject();
        //LostSpawn spawner = spawnerOb.AddComponent<LostSpawn>();
        //spawner.init(this , 6f);

        // lv = this.gameObject.AddComponent<Level>();
        levelSelector();
        
        UnityStandardAssets._2D.Camera2DFollow cam= transform.GetComponentInChildren<UnityStandardAssets._2D.Camera2DFollow>();
        cam.target = head.transform;
        cam.enabled = true;
        
        InvokeRepeating("Move", fr, fr);
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.position = SnakeList[0].transform.position;
        //check if button is pressed - update direction accordingly
        prevDir = direction;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = -Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = -Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right ;
        }
        //direction = direction / 2f;
       
        
    }

    void Move()
    {
        //HERE IS WHERE I CAN ADD AN IF STATMENT TO KILL THE SNAKE IF HE RUNS INTO HIMSELF WITH 2,3, or 4 cats in line
        Vector2 v = head.gameObject.transform.position;

        head.moveNode(direction,v);

        if (ate)
        {            
            GameObject og = new GameObject();
            Node n = og.AddComponent<Node>();
            n.init(v, false, this);
            SnakeList.Add(n);
            // Reset the flag
            ate = false;
        }

        if (SnakeList.Count > 1)
        {
            Node last = SnakeList[SnakeList.Count - 1];
            last.moveNode(prevDir,v);
            
            SnakeList.Insert(1, last);
            SnakeList.RemoveAt(SnakeList.Count - 1);
        }

    }

    //Adds correct Level component to the current scene, based on the 
    void levelSelector()
    {
        switch (lvNum)
        {
            case 1:
                lv = this.gameObject.AddComponent<Lv1>();
                break;
            default:
                break;                
        }
        lv.init(this);
        lv.setup();
    }

    
    public List<Lost> getCats()
    {
        return CatList;
    }
   

}
// To DO
//-think about loading levels, writing levelbuilder or designing in game
//-animations
//-MENU!!!
//-enemies
//-surprise cards (dad comes to take away kids, double the kittens, speed up, slow down)
//something about trash cans