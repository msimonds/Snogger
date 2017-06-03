using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    float type;
    Stream stream;
    Rigidbody2D body;
    BoxCollider2D coll;
    Vector2 velocity;
	// Use this for initialization
	void Start () {
	
	}

    public void init(Stream s, float type, Vector2 velocity)
    {
        this.type = type;
        this.stream = s;
        
        this.transform.parent = s.transform;
        this.transform.position = s.transform.position;
       
        //this.gameObject.AddComponent<MeshRenderer>();
        SpriteRenderer render = this.gameObject.AddComponent<SpriteRenderer>();
        Sprite[] spritez = Resources.LoadAll<Sprite>("Sprites/Breakwall");
        render.sprite = spritez[0];
        this.velocity = velocity;
       // this.body = gameObject.AddComponent<Rigidbody2D>();
       // this.body.gravityScale = 0;
       // this.body.isKinematic = false;
        this.coll = gameObject.AddComponent<BoxCollider2D>();
        this.coll.size = new Vector2(0.2f, 0.3f);
        
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {

        transform.position += (Vector3)velocity * Time.deltaTime;
        


    }
}
