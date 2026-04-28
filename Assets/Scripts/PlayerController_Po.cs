using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Po : MonoBehaviour
{
    public string nextScene;
    
    public Rigidbody2D rigidBody;

    public float jumpForce = 50f;
    public float vel = 0;
    public int direction = 0;

    public int n_Saltos = 0;
    public int saltos_Max = 2;

    public bool isGrounded;

    public bool needKeys = false;
    public bool hasKey = false;
    public int keysNeeded = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();

    }
    void Jump() 
    {
            
        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        //{
        //    rigidBody.AddForce(new Vector2(0, jumpForce));      
        //}

        if (Input.GetKeyDown(KeyCode.Space) && n_Saltos < saltos_Max)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            n_Saltos++;

        }
    }

    void Move() 
    {
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }
        this.gameObject.transform.Translate(new Vector2(direction * vel * Time.deltaTime,0));   //al pulsar A o D, manteniendo, no paraaaaaa
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            isGrounded = true;
            n_Saltos= 0;
        }

        if (collision.gameObject.tag == "Key") 
        {
            Destroy(collision.gameObject);
            keysNeeded--;
            if (keysNeeded <= 0)
            {
                hasKey = true;
            }
        }

        if (collision.gameObject.tag == "Exit")
        {
            if (needKeys == false || hasKey == true)
            {
                SceneManager.LoadScene("Scene_" + nextScene);
            }
            
        }

        if (collision.gameObject.tag == "Collect")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    
}
