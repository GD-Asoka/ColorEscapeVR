using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LevelManager : MonoBehaviour
{
    public GameObject exit;
    public Text blue, green, orange;
    public int blueW, greenW, orangeW;
    public ParticleSystem win, lose;
    public GameObject[] level3;
    private Vector3[] positions = new Vector3[3];
    public bool bLevel3;

    private void Start()
    {
        if(bLevel3)
        {
            for(int i = 0; i < level3.Length; i++)
            {
                positions[i] = level3[i].transform.position;
            }
        }
    }

    public void CheckWin()
    {
        //Start testing
        //exit.GetComponent<Rigidbody>().isKinematic = false;
        //win.Play();
        //AudioManager.instance.PlaySound(AudioManager.SFX.win);
        //GameManager.instance.LevelUp();
        //return;
        //End Testing

        if (int.Parse(blue.text) == blueW)
            if (int.Parse(green.text) == greenW)
                if (int.Parse(orange.text) == orangeW)
                {
                    exit.GetComponent<Rigidbody>().isKinematic = false;
                    win.Play();
                    AudioManager.instance.PlaySound(AudioManager.SFX.win);
                    GameManager.instance.LevelUp();
                    return;
                }

        blue.GetComponentInParent<IncrementUIText>().ResetText();
        green.GetComponentInParent<IncrementUIText>().ResetText();
        orange.GetComponentInParent<IncrementUIText>().ResetText();
        lose.Play();
        AudioManager.instance.PlaySound(AudioManager.SFX.wrong);
    }

    public void Level3Check()
    {
        foreach(GameObject go in level3)
        {
            if(go.activeSelf)
            {
                lose.Play();
                AudioManager.instance.PlaySound(AudioManager.SFX.wrong);
                return;
            }            
        }
        exit.GetComponent<Rigidbody>().isKinematic = false;
        win.Play();
        AudioManager.instance.PlaySound(AudioManager.SFX.win);
        GameManager.instance.LevelUp();
    }

    public void Level3Reset()
    {
        for(int i = 0; i < level3.Length; i++)
        {
            level3[i].transform.position = positions[i];
            level3[i].SetActive(true);
        }
    }
}
