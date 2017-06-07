using UnityEngine;
using System.Collections.Generic;


public class Lv1 : Level {

    //TODO: fix the sprites in diff places
    //finally just add menus and a scoring system

    // Use this for initialization
    int eventn;
    GameObject spawnerOb;
    List<Vector2> l2;

    public override void setup()
    {
        //10 in first room, fix sprites
        eventn=0;
        spawnerOb = new GameObject();
        LostSpawn spawner = spawnerOb.AddComponent<LostSpawn>();
        List<Vector2> l = new List<Vector2>();
        l.Add(new Vector2(0, 0));
        l.Add(new Vector2(0, -1));
        l.Add(new Vector2(4f, 3f));
        l.Add(new Vector2(0, -1));
        l.Add(new Vector2(-3f, 2f));
        l.Add(new Vector2(0, -1));    
        l.Add(new Vector2(0, 0));
        l.Add(new Vector2(4f, 3f));
        l.Add(new Vector2(0, 0));
        l.Add(new Vector2(-2f, 2f));
        l.Add(new Vector2(1f, -0f));
        l.Add(new Vector2(4f, 0f));
        l.Add(new Vector2(-5.0f, 8f));
        l.Add(new Vector2(7f, 8f));
        
        spawner.init(sn, 6f, l, new Vector4(-4.5f, 5, 4, -1));
        
        l2 = new List<Vector2>();       

        GameObject bob1 = new GameObject();
        Basket b1 = bob1.AddComponent<Basket>();
        GameObject t= GameObject.Find("BasketDoor1");
        List<GameObject> target = new List<GameObject>();
        target.Add(t);
        b1.init(sn, 10, new Vector2(-5, -1), target);
        GameObject bob2 = new GameObject();
        Basket b2 = bob2.AddComponent<Basket>();
        target = new List<GameObject>();
        target.Add(GameObject.Find("BasketDoor2"));
        b2.init(sn, 15, new Vector2(8, 6), target);

        GameObject streamo = new GameObject();
        Stream str = streamo.AddComponent<Stream>();
        List<float> pattern = new List<float>();
        str.init(sn, new Vector2(8.5f, 10f), Vector2.left, 3f, pattern);

        GameObject streamo1 = new GameObject();
        Stream str1 = streamo1.AddComponent<Stream>();
        str1.init(sn, new Vector2(-5.75f, 7), Vector2.right, 3f, pattern);
    }
	void Start () {
      
    }
    
    public override void setEvent()
    {
        eventn += 1;
    }   
	
	// Update is called once per frame
	void Update () {
        if (eventn==2)
        {
            Destroy(spawnerOb);
            GameObject spawnerOb2 = new GameObject();
            LostSpawn spawnerr = spawnerOb2.AddComponent<LostSpawn>();

            spawnerr.init(sn, 6f, l2, new Vector4(-2.5f, 4, 16, 12.84f));
            eventn = 3;


        }
       
	
	}
}
