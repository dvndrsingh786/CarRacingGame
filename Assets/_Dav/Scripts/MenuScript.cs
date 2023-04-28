using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dav
{
    public class MenuScript : MonoBehaviour
    {
        public GameObject[] carsObjects;
        public Transform[] carPositions;
        public int currentSelectedCarIndex;

        private void Start()
        {
            currentSelectedCarIndex = PlayerData.instance.selectedCarIndex;
        }

        void SetCarWithIndex()
        {

        }

    }
}