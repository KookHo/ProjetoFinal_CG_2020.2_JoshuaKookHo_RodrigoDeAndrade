using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerThatWorks : MonoBehaviour{
    public GameObject[] groups;
    

    public void spawnSomething(){
        int i = Random.Range(0, groups.Length);

        Instantiate(groups[i], transform.position, Quaternion.identity);
    }

    public void spawnSomethingFirst(){
        int i = Random.Range(0, groups.Length);

        Instantiate(groups[i], transform.position, Quaternion.identity);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spawnSomethingFirst();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
