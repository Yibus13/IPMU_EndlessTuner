
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centralPos = Player.position + offset;
        centralPos.x = 0;
        transform.position = centralPos;
    }
}
