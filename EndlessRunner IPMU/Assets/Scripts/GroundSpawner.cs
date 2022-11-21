using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground;
    Vector3 spawnPoint;



    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(ground, spawnPoint, Quaternion.identity);
        spawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems){
            temp.GetComponent<GroundTile>().spawnObstacle();
            temp.GetComponent<GroundTile>().SpawnPoint();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 15; i++) {
            if(i < 3){
                SpawnTile(false);
            }else{
                SpawnTile(true);
            }
            
        }
    }

   
}
