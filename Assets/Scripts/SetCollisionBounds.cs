using System;
using UnityEngine;

public class SetCollisionBounds : MonoBehaviour
{
    private Resolution _resolution;
    private bool ResolutionsAreEqual(Resolution a, Resolution b)
    {
        return a.width == b.width && a.height == b.height;
    }

    private void AvoidPlayerPositionOverflow(Vector3 leftOuterBoundPosition, Vector3 rightOuterBoundPosition)
    {
        GameObject player = GameObject.FindGameObjectWithTag(Constants.Tags.Player);
        if(player.transform.position.x < leftOuterBoundPosition.x || 
            player.transform.position.x > rightOuterBoundPosition.x)
        {
            Vector3 newPosition;
            newPosition = player.transform.position;
            float spriteWidthOffset = player.GetComponent<SpriteRenderer>().bounds.size.x / 2;
            if (player.transform.position.x < leftOuterBoundPosition.x)
            {
                newPosition.x = leftOuterBoundPosition.x + spriteWidthOffset; 
            }
            else if (player.transform.position.x > rightOuterBoundPosition.x)
            {
                newPosition.x = rightOuterBoundPosition.x - spriteWidthOffset;
            }
            player.transform.position = newPosition;
        }
        
    }

    private void MoveBounds()
    {
        GameObject LeftOuterBound = GameObject.Find(Constants.GameObjects.LeftOuterBound);
        GameObject RightOuterBound = GameObject.Find(Constants.GameObjects.RightOuterBound);
        Bounds bounds = Utils.OrthographicBounds();
        Vector3 newPosition = LeftOuterBound.transform.position;
        newPosition.x = bounds.min.x;
        LeftOuterBound.transform.position = newPosition;
        newPosition = RightOuterBound.transform.position;
        newPosition.x = bounds.max.x;
        RightOuterBound.transform.position = newPosition;
        AvoidPlayerPositionOverflow(LeftOuterBound.transform.position, RightOuterBound.transform.position);
    }

    private void Awake()
    {
        MoveBounds();
    }

    private void Start()
    {
        _resolution = Screen.currentResolution;
    }

    private void Update()
    {
        if(!ResolutionsAreEqual(_resolution, Screen.currentResolution))
        {
            _resolution = Screen.currentResolution;
            MoveBounds();
        }
    }
}
