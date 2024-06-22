using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip winSFX, redoSFX, deathSFX, wrongSFX;
    private AudioSource audioSource;
    public enum SFX
    {
        win,
        redo,
        death,
        wrong,
    }

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SFX sound)
    {
        switch (sound)
        {
            case SFX.win:
                StartCoroutine(Win());
                break;
            case SFX.death:
                StartCoroutine(Death());
                break;
            case SFX.redo:
                audioSource.PlayOneShot(redoSFX);
                break;
            case SFX.wrong:
                audioSource.PlayOneShot(wrongSFX);
                break;
        }
    }

    public void Redo()
    {
        PlaySound(SFX.redo);
    }

    private IEnumerator Win()
    {
        var temp = audioSource.clip;
        audioSource.clip = winSFX;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = temp;
        audioSource.Play();
    }
    
    private IEnumerator Death()
    {
        var temp = audioSource.clip;
        audioSource.clip = deathSFX;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = temp;
        audioSource.Play();
        GameManager.instance.Restart();
    }

}
