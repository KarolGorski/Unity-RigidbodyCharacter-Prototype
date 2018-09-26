using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallsManager : MonoBehaviour {

    List<InvisibleWall> invisibleWallsList;

    private void Start()
    {
        invisibleWallsList = new List<InvisibleWall>();
        invisibleWallsList.AddRange(GameObject.FindObjectsOfType<InvisibleWall>());
    }

    public void UpdateAllWalls(bool isPlayerGrounded)
    {
        foreach (InvisibleWall i in invisibleWallsList)
            i.UpdateInvisibleWall(isPlayerGrounded);
    }
}
