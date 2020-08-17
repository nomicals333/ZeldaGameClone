using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sign : MonoBehaviour
{
    // Added to check git push AGAIN CHECKING 9.08am**

    #region Variables
    // Refernce the dialog box itself
    public GameObject dialogBox;

    // Reference the text
    public Text dialogText;

    // Reference the string we want to replace in the dialog box
    public string dialog;

    // to show whether or not dialog box should be active
    public bool playerInRange;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    // built in unity method
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check to see if other is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);

        }
    }
    #endregion
}
