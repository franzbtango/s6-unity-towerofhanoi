using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Rod> Rods = new List<Rod>();
    private GameObject refDisk;
    private bool isLifting = false;

    [SerializeField]
    private int diskCount;
    [SerializeField]
    private GameObject[] diskSprites;

    private InputManager inputManager;

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
        }
    }
    
    void Update()
    {
        //Debug.Log(Rods[0].Disks.Count + " " + Rods[1].Disks.Count + " " + Rods[2].Disks.Count);
        if (inputManager.ButtonA)
            OnMoveDisk(Rods[0]);
        else if (inputManager.ButtonS)
            OnMoveDisk(Rods[1]);
        else if (inputManager.ButtonD)
            OnMoveDisk(Rods[2]);
    }

    void OnMoveDisk(Rod refRod) {
        if (!isLifting) {
            if (refRod.Disks.Count > 0) {
                isLifting = true;
                refDisk = refRod.Disks.Values[0];
                refDisk.GetComponent<DiskScript>().LiftDisk(refRod);
            }
        } else {
            if (refRod.Disks.Count > 0 ? refRod.Disks.First().Key > refDisk.GetComponent<DiskScript>().ID : true) {
                isLifting = false;
                refDisk.GetComponent<DiskScript>().DropDisk(refRod, false);
            }
        }
    }
}
