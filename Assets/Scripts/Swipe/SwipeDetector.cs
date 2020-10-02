using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private float minDistanceForSwipe = 20f;
    public Text test;

    SwipeDirection swipeDirection;
    SwipeDirection nextSwipeDirection;
    int val = 1;
    void start()
    {
        nextSwipeDirection = SwipeDirection.Up;
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipeDirection();

                if (swipeDirection == nextSwipeDirection)
                {
                    test.text = "SWIPE " + Enum.GetName(typeof(SwipeDirection), val) + " !";
                    print("Swipe detected...");
                    nextSwipeDirection = (SwipeDirection)val;
                    val++;
                    if (val > 3)
                    {
                        val = 0;
                    }
                }
            }
        }
    }

    private void DetectSwipeDirection()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                swipeDirection = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;

            }
            else
            {
                swipeDirection = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;

            }
            fingerUpPosition = fingerDownPosition;

        }


    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }
}
    
public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}