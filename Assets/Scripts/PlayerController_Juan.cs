using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Juan : MonoBehaviour
{
    public string nextScene;

    public Rigidbody2D rigidBody;

    public float jumpForce = 50f;
    public float vel;
    public int direction = 0;
    public bool isGrounded;

    public int numSaltos;
    public int saltosMax;

    public bool needKeys = false;
    public bool hasKeys = false;
    public int keysNeed = 1;

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
        this.gameObject.transform.Translate(new Vector2(direction * vel * Time.deltaTime, 0));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            numSaltos++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && numSaltos < saltosMax)
        {
            numSaltos++;
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            numSaltos = 0;
        }
        if (collision.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Key")
        {
            Debug.Log("LLave obtenida");
            Destroy(collision.gameObject);
            keysNeed--;
            if (keysNeed <= 0) 
            {
                hasKeys = true;
            }
        }
        if (collision.gameObject.tag == "Exit")
        {
            if (hasKeys == true || needKeys == false)
            {
                Debug.Log("Has llegado a la salida");
                SceneManager.LoadScene("Scene_" + nextScene);
            }
        }
        if (collision.gameObject.tag == "Collectable")
        {
            Debug.Log("Coleccionable obtenido");
            Destroy(collision.gameObject);
        }

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

}
