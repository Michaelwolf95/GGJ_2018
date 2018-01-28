using UnityEngine;

namespace GGJ_2018
{
    public class AutoUnparentAtStart : MonoBehaviour
    {
        private void Start()
        {
            this.transform.SetParent(null);
        }
    }
}