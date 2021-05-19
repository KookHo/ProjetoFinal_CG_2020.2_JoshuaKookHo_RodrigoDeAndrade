using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield : MonoBehaviour{

    public static int destroyCounter = 0;

    public static int width = 10;
    public static int height = 20; 
    public static Transform[,] grid = new Transform[width, height];
    public static int deletedRows = 0;
    public static float tetrominoFallTime = 1f;
    public static int score;
    public static int currentTetromino;

    //public static TextMeshProUGUI scoreText;

    public static Vector2 roundVector(Vector2 v){
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool insideBorder(Vector2 pos){
        return ( (int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    /*public static void updateScore(){
        scoreText.text = "Score: " + score.ToString(); 
    }*/

    public static void deleteRow(int y){
        for (int x = 0; x < width; x++){
            Destroy(grid[x,y].gameObject);
            grid[x,y] = null;
        }
        deletedRows += 1;
        score += 150;
        if (deletedRows%10 == 0 && tetrominoFallTime != 0.1f) {
            tetrominoFallTime = tetrominoFallTime - 0.1f;
        }
    }

    public static void decreaseRow(int y){
        for( int x = 0; x < width; x++){
            if (grid[x,y] != null){
                grid[x, y-1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y-1].position += new Vector3(0,-1,0);
            }
        }
    }

    public static void decreaseRowsAbove(int y){
        for(int i = y; i < height; i++){
            decreaseRow(i);
        }
    }

    public static bool isRollFull(int y){
        for (int x = 0; x < width; x++){
            if (grid[x,y] == null)  return false;            
        }
        return true;
    }

    public static void deleteFullRows(){
        for (int y = 0; y < height; y++){
            if ( isRollFull(y) ){
                deleteRow(y);
                decreaseRowsAbove(y+1);
                y = y-1;
            }
        }
    }
    // Start is called before the first frame update
    void Start(){
        score = 0;
        deletedRows = 0;
        tetrominoFallTime = 1f;
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
