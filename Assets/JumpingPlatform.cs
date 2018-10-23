    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class JumpingPlatform : MonoBehaviour
    {

        public float jumpForce = 500f;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce,ForceMode.Impulse);
            
            }
        }    
    }
