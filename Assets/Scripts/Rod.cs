using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod
{
    public int ID { get; set; }
    public SortedList<int, GameObject> Disks { get; set; }

    public Rod(int id) {
        ID = id;
        Disks = new SortedList<int, GameObject>();
    }

    public void AddDisk(int id, GameObject disk) {
        disk.GetComponent<DiskScript>().ID = id;
        disk.GetComponent<DiskScript>().PlaceDisk(this);
        Disks.Add(id, disk);
    }
}
