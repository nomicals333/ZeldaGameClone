using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    // GUS Copy
    #region Variables
    // How much we shift the camer
    public Vector2 cameraChange;

    // How much we shift the player
    public Vector3 playerChange;

    // reference to CameraMovement script
    private CameraMovement cam;

    //variable for what rooms need text displayed or not.
    public bool needText;

    // holds the place name for reference
    public string placeName;

    // Reference to the object
    public GameObject text;

    // reference to the text on that object
    public Text placeText;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Reference to camera script
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check to see its the player in the trigger zone
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;

            // Move the player
            other.transform.position += playerChange;

            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    // Co routine for set text and waiting specified time to display
    private IEnumerator placeNameCo()
    {
        // make the object active
        text.SetActive(true);
        // change the text part of it
        placeText.text = placeName;
        // wait for 4 seconds
        yield return new WaitForSeconds(4f);
        // Turn the object off
        text.SetActive(false);

    }
}
