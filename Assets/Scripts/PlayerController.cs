using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Speed at which the block moves
    public float speed = 5f;
    public int CoinsCollectedHahaha = 0;
    public AudioClip CoinSound;
    public AudioClip Oof;
    public bool OofSoundOn;
   

    void Update()
    {
        // Move the block up and down based on W and S keys
        transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        // Move the block left and right based on A and D keys 
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        
    }
    
    // This function is called when the collider /rigidbody attached to this script 
    // First touches another collider/rigidbody.

    private void OnCollisionEnter (Collision collision)
    {
        // Output the name of object that collided with this one
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if(collision.gameObject.tag == "platform" && OofSoundOn) 
        {
            AudioSource.PlayClipAtPoint(Oof,transform.position);
        }
        
       

        // You can add more logic here to handle the collision as needed 
    }

    // This function is called every frame while the collider/rigidbody is touching
    // another collider/rigidbody.

    private void OnCollisionStay(Collision collision)
    {
        // You can implement repeated behaviour while in contact if needed 
    }

    // This function is called when the collider/rigidbody attached stops touching another
    // collider/rigidbody

    private void OnCollsionExit (Collision collision)
    {
        // Handle logic for when collision ends
        Debug.Log("Stopped colliding with " + collision.gameObject.name);
    }


    // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // // //

   
    // This function is called when another collider enters the trigger for collider of this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision involves a specific tag, for example, "Enemy"
        
        
        {
            Debug.Log("Trigger entered by " + other.gameObject.name);
            // You can perform any actions you want here , like dealing damage, triggering effects, etc.

            if (other.gameObject.tag == "coin")
            {
                Destroy(other.gameObject);
                CoinsCollectedHahaha++;

                AudioSource.PlayClipAtPoint(CoinSound, transform.position);

            } 

        }
    }

    // This function is called when another collider exits the trigger collider of this GameObject
    private void OnTriggerExit(Collider other)
    {
        // You can implement additional actions here if needed
        Debug.Log("Trigger exited by " + other.gameObject.name);
    }

    //This funciton is called every frame while another collider stays in the trigger collider of this GameObject
    private void OnTriggerStay(Collider other)
    {
        // You can implement additional actions here if needed 
       // Debug.Log("We are in contact with enemy");
    }
}

