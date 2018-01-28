
using UnityEngine;

namespace GGJ_2018 {
    public class Door : MonoBehaviour {
        public bool player = false, patient = false, doctor = false;
        public bool open = false;

        void OnTriggerEnter2D(Collider2D c) {
            var go = c.attachedRigidbody ? c.attachedRigidbody.gameObject : c.gameObject;
            if ((player && go.tag == "Player")||
                (patient && go.tag == "Patient")||
                (doctor && go.tag == "Doctor")) {
                open = true;
                OpenDoor();
            }
        }

        public void OpenDoor() {
			GetComponent<Animator>().SetBool("open", true);
            //this.gameObject.SetActive(false);
        }
    }
}
