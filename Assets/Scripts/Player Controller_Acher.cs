using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Acher : MonoBehaviour
{
    public Rigidbody2D RB;
    public float jumpheight = 770;
    public float vel = 1;
    public int direction = 0;
    public bool isGrounded;
    public int Njumps = 0;
    public int Maxjumps = 2;
    public bool Levelneedkeys = false;
    public int needKeys = 0;
    public int neededkeys = 0;
    public string SceneName;

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();
    }
    void Move ()
    {
        this.gameObject.transform.Translate(new Vector2(direction*vel*Time.deltaTime, 0));
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

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Njumps < Maxjumps)
        {
            RB.AddForce(new Vector2(0, jumpheight));
            Njumps++;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Njumps = 0;
        }
        if (collision.gameObject.CompareTag("Pikito"))
            SceneManager.LoadScene("Scene_Acher");
        if (collision.gameObject.CompareTag("Coleccionable"))
            Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Llave"))
            Destroy(collision.gameObject);
            neededkeys--;
        if (collision.gameObject.CompareTag("Salida"))
            SceneManager.LoadScene("Scene_" + SceneName);
    }
}
