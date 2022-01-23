using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Used for movement and key input(s)
using TMPro; // Used for GUI and 

public class PlayerController : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;


    // Called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
    }

    // When input is given to the Player GameObject
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Called a specific number of times per tick
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speedMultiplier);
    }

    // When the player GameObject enters a new Trigger GameObject
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            count++;
            SetCountText();
            other.gameObject.SetActive(false);
        }

    }

    // Called only from OnTriggerEnter() when a player collects a Collectible
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/12";
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

}
