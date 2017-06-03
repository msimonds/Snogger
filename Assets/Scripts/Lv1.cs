using UnityEngine;
using System.Collections.Generic;


public class Lv1 : Level {

    //TODO: Fix spawning lists, add animations, add a spikey thing
            //finally just add menus and a scoring system

	// Use this for initialization

    public override void setup()
    {
        GameObject spawnerOb = new GameObject();
        LostSpawn spawner = spawnerOb.AddComponent<LostSpawn>();
        List<Vector2> l = new List<Vector2>();
        l.Add(new Vector2(0, 0));
        l.Add(new Vector2(0, -2));
        l.Add(new Vector2(0, 2));
        l.Add(new Vector2(2, 0));
        spawner.init(sn, 6f, l);

        GameObject bob1 = new GameObject();
        Basket b1 = bob1.AddComponent<Basket>();
        GameObject target = GameObject.Find("BasketDoor1");
        b1.init(sn, 2, new Vector2(3, 0), target);
        GameObject bob2 = new GameObject();
        Basket b2 = bob2.AddComponent<Basket>();
        target = GameObject.Find("BasketDoor2");
        b2.init(sn, 2, new Vector2(2, 8), target);



        GameObject streamo = new GameObject();
        Stream str = streamo.AddComponent<Stream>();
        List<float> pattern = new List<float>();
        str.init(sn, new Vector2(9.25f, 9.75f), Vector2.left, 3f, pattern);

        GameObject streamo1 = new GameObject();
        Stream str1 = streamo1.AddComponent<Stream>();
        str1.init(sn, new Vector2(-6, 6), Vector2.right, 3f, pattern);
    }
	void Start () {
      
    }   
	
	// Update is called once per frame
	void Update () {
	
	}
}
