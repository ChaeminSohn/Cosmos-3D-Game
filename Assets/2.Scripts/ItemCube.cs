using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCube : MonoBehaviour
{
    public float RotateSpeed = 17;

    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 0) * RotateSpeed * Time.deltaTime);
    }

    /*void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.itemCount++;
            audio.Play();
            gameObject.SetActive(false);
        }
    }*/
}
