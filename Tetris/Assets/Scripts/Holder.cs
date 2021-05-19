using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour{

    public GameObject[] groups;
    public static int hold;//diz qual peça ta segurando
    public static int holding;//diz se ta segurando algo

    public void holdOrSwitch(){
        int i = Playfield.currentTetromino;
        if(holding < 0){
            Instantiate(groups[i], transform.position, Quaternion.identity);
            hold = i;
            holding = 1;
        }else{
            GameObject oldH = GameObject.FindWithTag("Hold");
            Destroy(oldH);
            Instantiate(groups[i], transform.position, Quaternion.identity);
            Playfield.currentTetromino = hold;
            hold = i;
        }
    }

    // Start is called before the first frame update
    void Start(){
        hold = Playfield.currentTetromino;
        holding = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
