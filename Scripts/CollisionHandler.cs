using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Fuel":
                AddFuel();
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
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
