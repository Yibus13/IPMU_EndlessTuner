using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public float rot = 90f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rot * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }
        if(other.gameObject.name != "Player"){
            return;
        }

        GameManager.inst.AddScore();

        Destroy(gameObject);
    }
}
