using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int moveCount { get; private set; }

    private List<Rod> Rods = new List<Rod>();
    private GameObject refDisk;
    private bool isLifting = false;

    private int diskCount;
    [SerializeField]
    private GameObject[] diskSprites;

    private InputManager inputManager;
    private UIManager uiManager;

    void Awake() {
        inputManager = GetComponent<InputManager>();
        uiManager = GetComponent<UIManager>();
        diskCount = Globals.instance.diskCountAmount;
        Globals.instance.gameIsPaused = false;
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
        if (!Globals.instance.gameIsPaused) {
            if (inputManager.ButtonA)
                OnMoveDisk(Rods[0]);
            else if (inputManager.ButtonS)
                OnMoveDisk(Rods[1]);
            else if (inputManager.ButtonD)
                OnMoveDisk(Rods[2]);
            else if (inputManager.ButtonESC)
                uiManager.PauseGame();
        }
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
                moveCount++;
                uiManager.ChangeMoveCountText(moveCount.ToString());
                refDisk.GetComponent<DiskScript>().DropDisk(refRod, false);
                if (Rods[2].Disks.Count >= diskCount) {
                    uiManager.GameFinished(moveCount.ToString(), CalculateMinimumMoves());
                }
            }
        }
    }

    string CalculateMinimumMoves() {
        return (Mathf.Pow(2, diskCount) - 1).ToString();
    }
}
