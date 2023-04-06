using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField]
    string triggeringTag;

    [SerializeField]
    private AudioClip expSoundEffect;

    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(expSoundEffect, transform.position);
            GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(exp, 0.75f); //destroy the explosion object after a specifc time
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
