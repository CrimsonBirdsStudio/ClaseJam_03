using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_raquelr : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public string NextScene;
    public float jumpForce = 50f;

    public int jumpsCount;
    public int maxJumps = 2;

    public float vel;
    public int direction = 0;

    public bool needKeys = false;
    public bool hasKeys = false;
    public int keysNeeded = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < maxJumps)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            jumpsCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpsCount = 0;
        }
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            keysNeeded--;
            if (keysNeeded <= 0)
            {
                hasKeys = true;
            }
        }
        if (collision.gameObject.tag == "Exit")
        {
            if (hasKeys == true || needKeys == false)
            {
                SceneManager.LoadScene("Scene_" + NextScene);
            }
        }
        if (collision.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemigo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
