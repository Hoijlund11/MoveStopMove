using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{   
    public Character character;
    private void OnTriggerEnter(Collider other)
    {
        Character c;
        if (other.CompareTag("Player"))
        {
            c = other.GetComponent<Character>();
            character.AddTarget(c);
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        character.RemoveTarget(other.GetComponent<Character>());
    }
}
