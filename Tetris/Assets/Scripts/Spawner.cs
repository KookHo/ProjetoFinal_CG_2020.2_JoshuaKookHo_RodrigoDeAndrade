using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    public GameObject[] groups;
    

    public void spawnNext(){
        int i = Previewer.nextTetromino;
        Playfield.currentTetromino = i;

        Instantiate(groups[i], transform.position, Quaternion.identity);
    }

    public void spawnFirst(){
        int i = Random.Range(0, groups.Length);
        Playfield.currentTetromino = i;

        Instantiate(groups[i], transform.position, Quaternion.identity);
    }

    public void switchT(){
        int i = Playfield.currentTetromino;
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()    {
        spawnFirst();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
