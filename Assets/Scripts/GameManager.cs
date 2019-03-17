using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Rod> Rods = new List<Rod>();

    [SerializeField]
    private int diskCount = 3;

    [SerializeField]
    private GameObject[] diskSprites;

    private InputManager inputManager;

    // brute force variables
    bool isLifting = false;
    GameObject refDisk;

    void Awake() {
        inputManager = GetComponent<InputManager>();
    }

    void Start()
    {
        Rods.Add(new Rod(0));
        Rods.Add(new Rod(1));
        Rods.Add(new Rod(2));
        
        for (int i = diskCount - 1; i >= 0; i--) {
            Rods[0].AddDisk(i, Instantiate(diskSprites[i]));
            //Rods[0].Disks.Add(i, new Disk(i));
            //Instantiate(diskSprites[i], new Vector3(-5.25f, -3 + (0.5f * i), 0), Quaternion.identity);
            //Debug.Log(i);
        }

        //foreach (KeyValuePair<int, Disk> disk in Rods[0].Disks) {
        //    GameObject _disk = Instantiate(diskSprites[disk.Key]) as GameObject;
        //    _disk.transform.position = disk.Value.Position;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Rods[0].Disks.Count + " " + Rods[1].Disks.Count + " " + Rods[2].Disks.Count);
        if (inputManager.ButtonA) {
            if (!isLifting) {
                if (Rods[0].Disks.Count > 0) {
                    isLifting = true;
                    refDisk = Rods[0].Disks.Values[0];
                    refDisk.GetComponent<DiskScript>().LiftDisk();
                    Rods[0].Disks.Remove(refDisk.GetComponent<DiskScript>().ID);
                }
            } else {
                Debug.Log(Rods[0].Disks.Count);
                if (Rods[0].Disks.Count > 0 ? Rods[0].Disks.First().Key > refDisk.GetComponent<DiskScript>().ID : true) {
                    isLifting = false;
                    refDisk.GetComponent<DiskScript>().PlaceDisk(Rods[0]);
                    Rods[0].AddDisk(refDisk.GetComponent<DiskScript>().ID, refDisk);
                }
            }
        } else if (inputManager.ButtonS) {
            if (!isLifting) {
                if (Rods[1].Disks.Count > 0) {
                    isLifting = true;
                    refDisk = Rods[1].Disks.Values[0];
                    refDisk.GetComponent<DiskScript>().LiftDisk();
                    Rods[1].Disks.Remove(refDisk.GetComponent<DiskScript>().ID);
                }
            } else {
                if (Rods[1].Disks.Count > 0 ? Rods[1].Disks.First().Key > refDisk.GetComponent<DiskScript>().ID : true) {
                    isLifting = false;
                    refDisk.GetComponent<DiskScript>().PlaceDisk(Rods[1]);
                    Rods[1].AddDisk(refDisk.GetComponent<DiskScript>().ID, refDisk);
                }
            }
        } else if (inputManager.ButtonD) {
            if (!isLifting) {
                if (Rods[2].Disks.Count > 0) {
                    isLifting = true;
                    refDisk = Rods[2].Disks.Values[0];
                    refDisk.GetComponent<DiskScript>().LiftDisk();
                    Rods[2].Disks.Remove(refDisk.GetComponent<DiskScript>().ID);
                }
            } else {
                if (Rods[2].Disks.Count > 0 ? Rods[2].Disks.First().Key > refDisk.GetComponent<DiskScript>().ID : true) {
                    isLifting = false;
                    refDisk.GetComponent<DiskScript>().PlaceDisk(Rods[2]);
                    Rods[2].AddDisk(refDisk.GetComponent<DiskScript>().ID, refDisk);
                }
            }
        }
    }
}
