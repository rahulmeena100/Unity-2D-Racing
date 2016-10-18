using UnityEngine;
using System.Collections;

public class CarSpawn : MonoBehaviour {

    public GameObject[] cars;
    int carNo;
    // public float maxPos = 2.6f;

    
    public float delayTimer = 1f;
    float timer;

	// Use this for initialization
	void Start () {
         timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.56f, 2.6f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 3);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }    
    }
}