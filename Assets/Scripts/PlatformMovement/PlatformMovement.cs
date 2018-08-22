using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    [SerializeField]
    List<Vector3> borderPoints;
    int currentListElement = 0;
    [SerializeField]
    float timeBetweenBorderPoints;
    bool inMovement = false;
    


    public void UpdateMovingPlatform()
    {
        if(borderPoints.Count<2)
        {
            Debug.LogError("There is too low amount of borderPoints in moving platform with name: " + this.gameObject.name);
            return;
        }
        if (inMovement) return;

        StartCoroutine(
            Movement(
                borderPoints[currentListElement], 
                borderPoints[currentListElement == borderPoints.Count - 1 ? 0 : currentListElement + 1]));
        currentListElement = (currentListElement + 1) % borderPoints.Count;

    }


    IEnumerator Movement(Vector3 startPos, Vector3 endPos)
    {
        inMovement = true;
        yield return null;

        for (float tempTime = 0f; tempTime <= timeBetweenBorderPoints; tempTime += Time.deltaTime)
        {
            this.gameObject.transform.position = Vector3.Lerp(
                startPos, 
                endPos, 
                tempTime / timeBetweenBorderPoints);

            yield return null;
        }

        inMovement = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            collision.transform.parent = transform;
            Debug.Log("Parenting");
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
        Debug.Log("Unparenting");
    }
}
