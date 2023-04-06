using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField]
    string triggeringTag;

    //[SerializeField] private GameObject[] hearts;
    [SerializeField]
    private int life;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    AudioClip lostLifeSoundEffect;

    [SerializeField]
    NumberField scoreField;

    [SerializeField]
    private GameObject heart;

    [SerializeField]
    private List<GameObject> hearts;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private SpriteRenderer sprite;

    private bool dead;
    private const int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            HitByShip(damage, other);
            if (dead)
            {
                PlayerDie(other);
            }
        }
    }

    private void Start()
    {
        life = hearts.Count;
    }

    //When hitbyShip deacres lifes, if he have less then 1 means he died.
    public void HitByShip(int d, Collider2D other)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(lostLifeSoundEffect, transform.position);
            Destroy(hearts[life].gameObject);
            hearts.RemoveAt(hearts.Count - 1);
            if (life < 1)
            {
                dead = true;
            }
        }
    }

    //Rewarding a life with placing a heart on the screen.
    //You can only have [0,amoutOfLifes]
    public void RewardALife(int amoutOfLifes)
    {
        if (life >= amoutOfLifes)
        {
            return;
        }

        Vector3 pos = hearts[hearts.Count - 1].transform.position + new Vector3(1.5f, 0, 0);
        GameObject new_heart = Instantiate(heart, Vector3.zero, canvas.transform.rotation);
        new_heart.transform.SetParent(canvas.transform, false);
        new_heart.transform.position = pos;
        hearts.Add(new_heart);
        life = hearts.Count;
    }

    public void PlayerDie(Collider2D other)
    {
        sprite.enabled = false;
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        //Destroy(exp,0.75f); //destroy the explosion object after a specifc time
        Invoke("GameEndMenu", 2f);
    }

    private void GameEndMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //go to the other scene(end)
        Destroy(this.gameObject);
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
