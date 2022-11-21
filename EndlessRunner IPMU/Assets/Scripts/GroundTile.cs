
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
    }

    void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstacle;

    public void spawnObstacle(){
        int index = Random.Range(2,5);
        Transform spawnPoint = transform.GetChild(index).transform;
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
    }
    public GameObject pointPrefab;

    public void SpawnPoint(){
        int amount = 10;
        for(int i = 0; i < amount; i++) {
            GameObject temp = Instantiate(pointPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
