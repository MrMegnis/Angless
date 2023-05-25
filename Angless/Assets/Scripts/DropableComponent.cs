using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropableComponent : MonoBehaviour {
    public GameObject[] items;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Drop() {
        foreach(GameObject item in items) {
            GameObject spawnedItem = Instantiate(item, gameObject.transform.position, Quaternion.identity);
        }
    }
}
