using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoint = 3;

    ScoreBoard scoreBoard;
    GameObject parent;
    MeshRenderer rendrer;
    Color primalColor;
    // int totalScore;

    void Start()
    {
        addingRigidBody();
        
        rendrer = GetComponent<MeshRenderer>();
        primalColor = rendrer.material.color;
        
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("Spawn");
    }

    private void Update()
    {
        rendrer.material.color = primalColor;
    }

    private void addingRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hitProcess();
        
        if(hitPoint <= 0)
        {
    	    destroyProcess();
        }
    }

    private void destroyProcess()
    {
        scoreBoard.increaseScore(scorePerHit);

        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent.transform;
        Destroy(gameObject);
    }

    private void hitProcess()
    {
        hitPoint--;
        // totalScore += scorePerHit;
        // scoreBoard.increaseScore(scorePerHit);

        rendrer.material.color = Color.red;
    }


}
