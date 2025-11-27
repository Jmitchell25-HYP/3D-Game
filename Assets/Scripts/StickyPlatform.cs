using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private Vector3 lastPlatformPosition;
    private GameObject player;


    private void Start()
    {
        lastPlatformPosition = transform.position; ;
    }

    private void OnCollision(Collision collision)
    {

        if (collision.gameObject.name == "Player")
        {

            player = collision.gameObject;
            lastPlatformPosition = transform.position;
        }


    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Player")
        {

            player = null;
        }





    }


    private void Update()
    {


        if (player != null)
        {

            // calculate how much the platform has moved since the last frame
            Vector3 platformMovement = transform.position - lastPlatformPosition;

            // Apply this movement offset to the Player's position
            player.transform.position += platformMovement;
        }

        // Updtae the last position for the next frame
        lastPlatformPosition = transform.position;








    }






}
