using UnityEngine;

public class PlayOneShot : MonoBehaviour
{
    public AudioClip soundEffect;
    public GameObject objectToPickUp;

    private AudioSource audioSource;

    private bool hasPickedUpObject = false;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Assign the sound effect to the AudioSource component
        audioSource.clip = soundEffect;
    }

    private void Update()
    {
        if (!hasPickedUpObject && objectToPickUp != null && objectToPickUp.activeSelf)
        {
            // Check if the object to pick up is within range and the player presses the pick up button (e.g. E key)
            if (Vector3.Distance(transform.position, objectToPickUp.transform.position) <= 2f && Input.GetKeyDown(KeyCode.E))
            {
                // Play the sound effect once
                audioSource.PlayOneShot(soundEffect);

                // Set a flag to prevent the sound effect from playing again if the object is already picked up
                hasPickedUpObject = true;

                // Deactivate the object to pick up
                objectToPickUp.SetActive(false);
            }
        }
    }
}
