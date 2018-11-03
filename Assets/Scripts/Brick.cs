using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public AudioClip crackAudio;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private Level_Manager _level_Manager;
    private bool isBreakable;


    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        _level_Manager = GameObject.FindObjectOfType<Level_Manager>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crackAudio, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            _level_Manager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        ParticleSystem smokeParticle = smokePuff.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule smokeParticleMain = smokeParticle.main;
        smokeParticleMain.startColor = this.GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, 2f);
    }

    private void LoadSprites ()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Brick Sprite Not Found"); //doesnt account for initial sprites on scene
        }
    }

    // ToDo Remove this method once we can actually win
    void SimulateWin()
    {
        breakableCount = 0;
        _level_Manager.LoadNextLevel();
    }
}
