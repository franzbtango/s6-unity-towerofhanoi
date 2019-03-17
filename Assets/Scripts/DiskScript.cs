using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskScript : MonoBehaviour
{
    public int ID { get; set; }
    public Vector2 Position { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceDisk(Rod destination) {
        //Debug.Log(destination.ID);
        int diskCount = destination.Disks.Count;
        Position = new Vector2(destination.ID == 0 ? -5.25f : destination.ID == 1 ? 0 : 5.25f, -3 + 0.5f * diskCount);
        transform.position = Position;
    }

    public void LiftDisk() {
        transform.position = new Vector2(transform.position.x, 3);
    }

    public void DropDisk() {

    }
}
