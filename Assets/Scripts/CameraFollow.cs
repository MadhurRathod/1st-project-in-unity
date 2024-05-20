using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    


    
    public Transform target; // The target position the camera will move towards
    public Vector3 offset = new Vector3(0, 5, -10); // The offset from the target position
    public float speed = 1.0f; // The speed of the movement
    public bool DoLookAt = false;

    private Vector3 startPosition;
    private bool isMoving = false;
    private float startTime;
    private float journeyLength;
    
    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not set. Please assign a target in the inspector.");
            return;
        }

        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, target.position);
    }

    void Update()
    {   //Optionally look at the target
        if (DoLookAt)
       transform.LookAt(target);

        if (isMoving)
        {
            // Calculate the distance covered based on the speed and time
            float distCovered = (Time.time - startTime) * speed;

            // Calculate the fraction of the journey completed
            float fractionOfJourney = distCovered / journeyLength;

            // Set the position of the camera using Lerp
            transform.position = Vector3.Lerp(startPosition, target.position, fractionOfJourney);

            // Stop moving if the camera has reached the target position
            if (fractionOfJourney >= 1.0f)
            {
                isMoving = false;
            }
        }


    }

    public void StartMoving()
    {
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, target.position);
        startTime = Time.time;
        isMoving = true;
    }

    void LateUpdate()
    {
        // Continuously follow the target with the specified offset
        if (!isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
        }
    }


    /* public GameObject Khiladi ;

     // Update is called once per frame
     void Update()
     {
         transform.position = new Vector3 (Khiladi.transform.position.x , Khiladi.transform.position.y , transform.position.z);
     }
    */
}
