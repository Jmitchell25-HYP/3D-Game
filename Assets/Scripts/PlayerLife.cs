using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlayerlLife : MonoBehaviour
{
    bool dead = false;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Invoke(nameof(Reloadlevel), 1.3f);
        dead = true;

    }

    void Reloadlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }










































}