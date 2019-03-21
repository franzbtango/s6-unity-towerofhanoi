using System.Collections;
using UnityEngine;

public class DiskScript : MonoBehaviour
{
    public int ID { get; set; }
    private Vector2 position;

    public void LiftDisk(Rod origin) {
        //transform.position = new Vector2(transform.position.x, 3.5f);
        StartCoroutine(LerpPosition(new Vector2(transform.position.x, 3.5f), 0.1f));
        origin.Disks.Remove(ID);
        FindObjectOfType<Globals>().Play("LiftDisk");
    }

    public void DropDisk(Rod destination, bool initial) {
        int diskCount = destination.Disks.Count;
        //position = new Vector2(destination.ID == 0 ? -5.25f : destination.ID == 1 ? 0 : 5.25f, -3 + 0.5f * diskCount);
        //transform.position = position;
        StartCoroutine(LerpPosition(new Vector2(destination.ID == 0 ? -5.25f : destination.ID == 1 ? 0 : 5.25f, -3 + 0.5f * diskCount), 0.1f));

        if (!initial) {
            destination.AddDisk(ID, this.gameObject);
            FindObjectOfType<Globals>().Play("DropDisk");
        }
    }

    private IEnumerator LerpPosition (Vector2 destination, float time) {
        float elapsedTime = 0 + Time.deltaTime;
        while(elapsedTime < time) {
            transform.position = Vector2.Lerp(transform.position, destination, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("test");
    }
}
