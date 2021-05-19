using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Previewer : MonoBehaviour{

    public GameObject[] groups;
    public static int nextTetromino = 0;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverObject;
    public GameObject gameOverButtonObject;
    public GameObject gameOverBGObject;
    public static bool gameOverCondition;

    public AudioSource BGM;
    public void previewNext(){

        GameObject oldT = GameObject.FindWithTag("Fake");
        Destroy(oldT);

        int i = Random.Range(0, groups.Length);

        Instantiate(groups[i], transform.position, Quaternion.identity); 

        nextTetromino = i;

        updateScore();

    }

    public void previewFirst(){
        int i = Random.Range(0, groups.Length);

        Instantiate(groups[i], transform.position, Quaternion.identity);

        nextTetromino = i;
    }

    void updateScore(){
        scoreText.text = "Score: " + Playfield.score.ToString(); 
    }

    // Start is called before the first frame update
    void Start(){
        previewFirst();
        updateScore();
        gameOverCondition = false;
        gameOverObject.SetActive(false);
        gameOverButtonObject.SetActive(false);
        gameOverBGObject.SetActive(false);
        BGM = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (gameOverCondition){
            gameOverObject.SetActive(true);
            gameOverButtonObject.SetActive(true);
            gameOverBGObject.SetActive(true);
            BGM.Stop();
        }
    }
}