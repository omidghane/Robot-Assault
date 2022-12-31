using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoadLevel = 1f;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] float timeGameEnd = 55.40f;

    private void Start() {
        
    }

    private void Update() {
        // Debug.Log(Time.time+" :time");
        // if(Time.time >= timeGameEnd)
        // {
        //     gameObject.GetComponent<ControlPlayer>().enabled = false;
        //     transform.localPosition = new Vector3(0,0,0);
        // }
    }

    void OnTriggerEnter(Collider other) {
        if(Time.time >= timeGameEnd)
        {
            return;
        }
        // Debug.Log("triggerd");
        explosionParticle.Play();
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<ControlPlayer>().enabled = false;
        Invoke("reloadScene",delayLoadLevel);
    }

    void reloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
}
