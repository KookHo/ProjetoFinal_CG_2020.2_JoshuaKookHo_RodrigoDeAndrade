using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour{

    bool isValidGridPos() {        
        foreach (Transform child in transform) {
            Vector2 v = Playfield.roundVector(child.position);

            if (!Playfield.insideBorder(v))
                return false;

            if (Playfield.grid[(int)v.x, (int)v.y] != null && 
                Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid() {
        // Remove old children from grid
        for (int y = 0; y < Playfield.height; ++y)
            for (int x = 0; x < Playfield.width; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform) {
            Vector2 v = Playfield.roundVector(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }        
    }
    
    float previousTime;
    float fallTime = Playfield.tetrominoFallTime;
    
    
    // Start is called before the first frame update
    void Start(){
        Debug.Log(fallTime);
        Debug.Log(Playfield.deletedRows);

        if (!isValidGridPos()){
            Debug.Log("GAME OVER");
            Previewer.gameOverCondition = true;
            
            if (Playfield.destroyCounter == 1){
                Destroy(gameObject);
            }else{
                Playfield.destroyCounter = 1;
            }
        }
    }

    // Update is called once per frame
    void Update(){
        //move left
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-1, 0, 0);
        
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
        //move right
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(1, 0, 0);
        
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0)){
            if (Holder.holding < 0){
                FindObjectOfType<Holder>().holdOrSwitch();   
                Destroy(gameObject);
                foreach (Transform child in transform){
                    Vector2 v = Playfield.roundVector(child.position);
                    Playfield.grid[(int)v.x, (int)v.y] = null;
                }
                        
                FindObjectOfType<Spawner>().spawnNext();
                FindObjectOfType<Previewer>().previewNext();
            }else{
                FindObjectOfType<Holder>().holdOrSwitch();  
                Destroy(gameObject);
                foreach (Transform child in transform){
                    Vector2 v = Playfield.roundVector(child.position);
                    Playfield.grid[(int)v.x, (int)v.y] = null;
                } 
                FindObjectOfType<Spawner>().switchT();
            }
            
        }

        //girar
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(0, 0, -90);
        
            if (isValidGridPos())
                updateGrid();
            else
                transform.Rotate(0, 0, 90);
        }
        //move down
        else if (Time.time - previousTime > ( Input.GetKey(KeyCode.DownArrow) ? fallTime/10 : fallTime) ) {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos()) {
                updateGrid();
            } else {
                transform.position += new Vector3(0, 1, 0);

                Playfield.deleteFullRows();
            
                FindObjectOfType<Spawner>().spawnNext();
                FindObjectOfType<Previewer>().previewNext();

                enabled = false;
            }
            previousTime = Time.time;
        }

    }
}
