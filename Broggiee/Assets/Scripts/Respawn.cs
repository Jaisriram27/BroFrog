using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public int PlayerRespawn;

    void Start()
    {

    }
    void Update()
    {

    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }  
    }
}