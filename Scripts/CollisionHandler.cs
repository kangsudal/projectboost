using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    AudioSource audioSource;

    bool isTrasitioning = false;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) {
        if(isTrasitioning){return;}
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence(){
        isTrasitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        //todo add particle effect upo crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }

    private void StartSuccessSequence(){
        isTrasitioning=true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
        audioSource.PlayOneShot(success);
    }

    private void AddFuel(){
        print("Add Fuel");
    }

    private void LoadNextLevel(){
        print("Success Landing!");
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIdx = currentSceneIdx+1;
        if(nextSceneIdx==SceneManager.sceneCountInBuildSettings){
            nextSceneIdx=0;
        }
        SceneManager.LoadScene(nextSceneIdx);
    }

    private void ReloadLevel(){
        int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIdx);
    }
}
