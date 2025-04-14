using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;
    private float verticalMidScreen;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenUpperLimit = 5.5f; //(JW) Found value through testing
    private float verticalScreenBottomLimit = -3.5f; //(JW) Found value through testing

    public GameObject bulletPrefab;

    void Start()
    {
        playerSpeed = 6f;
        verticalMidScreen = verticalScreenUpperLimit - ((verticalScreenUpperLimit - verticalScreenBottomLimit) / 2); //(JW)
        //This function is called at the start of the game
        
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();
        Testing(); // (JW)

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        // (JW) Player tries leaves the screen vertically at the bottom, keep at bottom of screen
        if(transform.position.y <= verticalScreenBottomLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenBottomLimit, 0);
        }
        // (JW) Player tries go back midscreen, keep at midscreen
        if(transform.position.y >= verticalMidScreen)
        {
            transform.position = new Vector3(transform.position.x, verticalMidScreen, 0);
        }
    }

    //(JW) Can be put in if any testing needed
    void Testing() 
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(transform.position.x);
        }
    }

}
