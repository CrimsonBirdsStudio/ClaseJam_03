using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float jumpfors;
    public GameObject prismaticos;
    public Camera lacam;
    int direction;
    public float vel;
    bool isgrounded;
    int saltos;
    int colectablesgot = 0;
    bool resetflag = true;
    int keysleft = 1;
    bool needkeys = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        moove();
    }


    void Jump()
    {
        rbody.AddForce(new Vector2(0, jumpfors - rbody.velocity.y*40));
    }
    void moove()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*|| Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)*/)
        {
            if (isgrounded)
            {
                Jump();
            }
            else
            {
                if (saltos < 1)
                {
                    saltos++;
                    Jump();
                }
            }
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" )
        {
            isgrounded = true;
            saltos = 0;
        }
        else if (collision.gameObject.tag == "spike" && resetflag)
        {
            resetflag = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "Colectable")
        {
            Destroy(collision.gameObject);
            colectablesgot++;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isgrounded = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            resetflag = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {
            if(collision.gameObject.tag == "prismaticos")
            {
                lacam.transform.position = prismaticos.gameObject.transform.position;
                lacam.orthographicSize = 28f;
            }
            else if (collision.gameObject.tag == "key")
            {
                Destroy(collision.gameObject);
                keysleft--;
            }
            else if (collision.gameObject.tag == "exit")
            {
                if (keysleft == 0 || needkeys == false)
                {
                    SceneManager.LoadScene("Scene_Profe");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "prismaticos")
        {
            lacam.orthographicSize = 5f;

            lacam.transform.localPosition = new Vector3(0, 0, -0.5f);
        }
    }
}
