using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskScript : MonoBehaviour
{
    public int ID { get; set; }
    private Vector2 position;

    public void LiftDisk(Rod origin) {
        transform.position = new Vector2(transform.position.x, 3.5f);
        origin.Disks.Remove(ID);
    }

    public void DropDisk(Rod destination, bool initial) {
        int diskCount = destination.Disks.Count;
        position = new Vector2(destination.ID == 0 ? -5.25f : destination.ID == 1 ? 0 : 5.25f, -3 + 0.5f * diskCount);
        transform.position = position;

        if (!initial)
            destination.AddDisk(ID, this.gameObject);
    }
}
