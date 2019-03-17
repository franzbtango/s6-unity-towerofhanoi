using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk
{
    public int ID { get; set; }
    public Vector2 Position { get; set; }

    public void MoveDisk(Rod destination) {
        //Debug.Log(destination.ID);
        int diskCount = destination.Disks.Count;
        Position = new Vector2(destination.ID == 0 ? -5.25f : destination.ID == 1 ? 0 : 5.25f, -3 + 0.5f * (diskCount - 1));
        Debug.Log(Position + " " + ID);
    }
}
