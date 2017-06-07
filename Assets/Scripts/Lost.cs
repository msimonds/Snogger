using UnityEngine;
using System.Collections;

public class Lost : MonoBehaviour {

    BoxCollider2D coll;
    LostSpawn ls;
    int spriteIndex = 0;
    Sprite[] spritez;
    float COOL = 1.0f;
    float stopwatch;
    SpriteRenderer render;

    // Use this for initialization
    void Start () {
	
	}

    public void init(Snake sn, Vector2 pos, LostSpawn ls)
    {
        this.ls = ls;
        GameObject model = new GameObject();
        model.transform.parent = transform;
        model.transform.localScale = new Vector2(1.849568f, 2.248518f);
        render = model.AddComponent<SpriteRenderer>();
        spritez = Resources.LoadAll<Sprite>("Sprites/cats");
        render.sprite = spritez[3];
        render.sortingLayerName = "Foreground";

        gameObject.tag = "LostCat";
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        coll.size = new Vector2(0.7f, 0.7f);
        coll.isTrigger = true;

        this.transform.position = pos;

    }

    // Update is called once per frame
    void Update () {

        if (stopwatch >= 0.05f && stopwatch >= COOL)
        {
            spriteIndex = (spriteIndex + 1) % 3;
            render.sprite = spritez[spriteIndex + 3];
            stopwatch = 0;
        }
        stopwatch += Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        print("hit cat");
        if (coll.gameObject.tag == "Head")
        {
            ls.clear = true;
            Destroy(this.gameObject);
        }

    }
    
}
