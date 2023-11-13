using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCheck : MonoBehaviour
{
    public int health = 100;
    private Animator _animator;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    IEnumerator LoadSceneAfterDelay(int sceneIndex, float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneBuildIndex: sceneIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            health -= 25;
            if (health <= 0)
            {
                _animator.SetBool("RunStart", false);
                playerMovement.SetRunSpeed(0);
                StartCoroutine(SceneManager.GetActiveScene().buildIndex == 0
                    ? LoadSceneAfterDelay(0, 1f)
                    : LoadSceneAfterDelay(1, 1f));
                
            }
            print("Health: " + health);
        }
        else if (other.CompareTag("HeavyObstacle"))
        {
            health -= 50;
            if (health <= 0)
            {
                _animator.SetBool("RunStart", false);
                playerMovement.SetRunSpeed(0);
                StartCoroutine(SceneManager.GetActiveScene().buildIndex == 0
                    ? LoadSceneAfterDelay(0, 1f)
                    : LoadSceneAfterDelay(1, 1f));
                
            }
            print("Health: " + health);
        }
        else if (other.CompareTag("Finish"))
        {
            _animator.SetBool("IsWin", true);
            
            playerMovement.SetRunSpeed(0);
            StartCoroutine(SceneManager.GetActiveScene().buildIndex == 1
                ? LoadSceneAfterDelay(0, 2f)
                : LoadSceneAfterDelay(1, 2f));
        }
        
    }
}
