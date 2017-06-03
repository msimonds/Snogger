using UnityEngine;
using System.Collections;

public class Lost : MonoBehaviour {

    BoxCollider2D coll;
    LostSpawn ls;

    // Use this for initialization
    void Start () {
	
	}

    public void init(Vector2 pos, LostSpawn ls)
    {
        this.ls = ls;
        GameObject model = new GameObject();
        model.transform.parent = transform;
        SpriteRenderer render = model.AddComponent<SpriteRenderer>();
        Sprite[] spritez = Resources.LoadAll<Sprite>("Sprites/ham1");
        render.sprite = spritez[0];

        gameObject.tag = "LostCat";
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        coll.size = new Vector2(0.7f, 0.7f);
        coll.isTrigger = true;

        this.transform.position = pos;

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Head")
        {
            ls.clear = true;
        }

    }
    
}
