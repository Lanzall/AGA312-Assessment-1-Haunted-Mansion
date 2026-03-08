using System;
using UnityEngine;

namespace StealthGame
{
    public class Door : MonoBehaviour
    {
        public string KeyName = "key1";
    
        private void OnCollisionEnter(Collision other)
        {
            NewPlayerMovement player = other.gameObject.GetComponent<NewPlayerMovement>();

            if (player == null)
                return;

            if (player.OwnKey(KeyName))
            {
                Destroy(gameObject);
            }
        }
    }
}