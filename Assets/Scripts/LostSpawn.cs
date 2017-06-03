using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LostSpawn : MonoBehaviour {

    //need a list of lostcats - in future might need to be updated to a list of possible LostCat locations 
    
    Snake snake;
    float time;
    float size;
    int curLost; //index of the next lost kitten to spawn    
    List<Vector2> posList; //list of the positions for the new kittens
    public bool clear = true; //true if the last kitten has been picked up

    public void init(Snake sn, float size, List<Vector2> l)
    {
        this.snake = sn;
        time = 0;
        this.size = size;
        posList = l;
        curLost = 0;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;       
        
        if (time > 5f && clear)
        {
            //We want to spawn a new cat
            clear = false;
            GameObject kitOb = new GameObject();
            Lost kitte = kitOb.AddComponent<Lost>();
            Vector2 position = (curLost == posList.Count) ? getPosition() : posList[curLost++];
            kitte.init(position, this);
            print("   time: " + Time.deltaTime);
            print(snake.getSnake()) ;
            snake.CatList.Add(kitte);
            time = 0;

        }
	}

    //Returns a position on the board that is not occupied by a LostCat 
    Vector2 getPosition()
    {
        Vector2 p=new Vector2(0,0);
        bool good = false;
        while (!good)
        {
            p = new Vector2(Mathf.RoundToInt( Random.Range(-6f, 6f)), Mathf.RoundToInt(Random.Range(-6f, 6f)));
            
            good = true; //assume it's a good position;
           // print(snake.CatList + " get pos "+ curLost);
            foreach(Lost cat in snake.CatList)
            {
                float cx = cat.transform.position.x;
                float cy = cat.transform.position.y;
                if  ((p.x-1<cx && cx> p.x + 1) && ((p.y-1<cy) && (p.y + 1 > cy))){
                    good = false;
                    
                }
            }

        }
        
        return p;
        
        
    }
}
