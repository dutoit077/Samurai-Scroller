using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public bool scrolling, parallax;
    public float backgroundSize;

    private Transform cameraTransfrom;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

    public float parallaxSpeed;
    public float lastCameraX;


    private void Start()
    {
        cameraTransfrom = Camera.main.transform;
        layers = new Transform[transform.childCount]; //how many screens the background is (3 in this case)
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;//lower bound
        rightIndex = layers.Length - 1;//upper bound
    }
    private void Update()
    {
        if(parallax)
        {
            float deltaX = cameraTransfrom.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraTransfrom.position.x;

        if (scrolling)
        {
            if (cameraTransfrom.position.x < (layers[leftIndex].transform.position.x + viewZone))
                ScrollLeft();
            if (cameraTransfrom.position.x > (layers[rightIndex].transform.position.x - viewZone))
                ScrollRight();
        }
       

    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize); //move the right image to the left 
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void ScrollRight()

    {
        
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize); //move the left image to the right
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
