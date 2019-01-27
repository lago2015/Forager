using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRandomPoint : MonoBehaviour {

    private float minX = -1300;
    private float maxX = 1100;
    private float minY = -1300;
    private float maxY = 1400;
    private Vector3 newPosition;

    public Vector3 FindNewPosition()
    {
        newPosition.x = Random.Range(minX, maxX);
        newPosition.y = Random.Range(minY, maxY);
        newPosition.z = 0;
        return newPosition;
    }
}
