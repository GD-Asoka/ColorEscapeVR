using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillY : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out CharacterController c))
        {
            AudioManager.instance.PlaySound(AudioManager.SFX.death);
            return;
        }
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySound(AudioManager.SFX.death);
    }
}
