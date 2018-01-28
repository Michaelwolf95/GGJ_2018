
using UnityEngine;

namespace GGJ_2018 {
    public class Door : MonoBehaviour {
        public bool player = false, patient = false, doctor = false;
        public bool open = false;

        void OnTriggerEnter(Collider c) {
            if ((player && c.gameObject.tag == "Player")||
                (patient && c.gameObject.tag == "Patient")||
                (doctor && c.gameObject.tag == "Doctor")) {
                open = true;
                OpenDoor();
            }
        }

        public void OpenDoor() {
            gameObject.SetActive(false);
        }
    }
}
