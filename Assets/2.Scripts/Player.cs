using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Transform tr;
    int JumpCnt = 0;
    public int itemCount;
    Rigidbody rigid;
    public float jumpPower = 10;
    AudioSource audio;
    public GameManager manager;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && (JumpCnt == 0))
        {
            JumpCnt = 1;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
        else if (Input.GetButtonDown("Jump") && (JumpCnt == 1))
        {
            JumpCnt = 2;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }


    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
        //transform.position += new Vector3(h, 0, v);
        //tr.Translate(Vector3.forward * 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            JumpCnt = 0;
        else if(collision.gameObject.tag == "Item")
        {
            itemCount++;
            audio.Play();
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Finish")
        {
            if (itemCount == 3)
            {
                SceneManager.LoadScene("SampleScene11");
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
