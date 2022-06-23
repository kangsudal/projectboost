using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                FinishAction();
                break;
            default:
                print("Bum!");
                break;
        }
    }

    private void AddFuel(){
        print("Add Fuel");
    }

    private void FinishAction(){
        print("Success Landing!");
    }
}
