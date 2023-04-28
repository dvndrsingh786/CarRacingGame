using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Dav
{
    public class MenuScript : MonoBehaviour
    {
        public Transform carsParent;
        public Transform carPositionsParent;
        public int currentSelectedCarIndex;

        private void Start()
        {
            currentSelectedCarIndex = PlayerData.instance.selectedCarIndex;
        }

        #region Cars Setup

        void InitialCarSetup()
        {
            int centerPoint = (carPositionsParent.childCount - ((carPositionsParent.childCount - 1) / 2)) - 1;
            for (int i = 0; i < currentSelectedCarIndex; i++)
            {
                carsParent.GetChild(i).localPosition = carPositionsParent.GetChild(centerPoint - currentSelectedCarIndex + i).localPosition;
            }
            int temp = 1;
            for (int i = currentSelectedCarIndex+1; i < carsParent.childCount; i++)
            {
                carsParent.GetChild(i).localPosition = carPositionsParent.GetChild(centerPoint + temp).localPosition;
                temp++;
            }
            carsParent.GetChild(currentSelectedCarIndex).localPosition = carPositionsParent.GetChild(centerPoint).localPosition;
        }

        public void SelectRightCarBtnClicked()
        {
            currentSelectedCarIndex++;
            if (currentSelectedCarIndex >= carsParent.childCount) currentSelectedCarIndex--;
            SetUpCarWithIndex();
        }

        public void SelectLeftCarBtnClicked()
        {
            currentSelectedCarIndex--;
            if (currentSelectedCarIndex < 0) currentSelectedCarIndex = 0;
            SetUpCarWithIndex();
        }

        void SetUpCarWithIndex()
        {
            int centerPoint = (carPositionsParent.childCount - ((carPositionsParent.childCount - 1) / 2)) - 1;
            for (int i = 0; i < currentSelectedCarIndex; i++)
            {
                carsParent.GetChild(i).DOLocalMove(carPositionsParent.GetChild(centerPoint - currentSelectedCarIndex + i).localPosition, 0.3f);
            }
            int temp = 1;
            for (int i = currentSelectedCarIndex + 1; i < carsParent.childCount; i++)
            {
                carsParent.GetChild(i).DOLocalMove(carPositionsParent.GetChild(centerPoint + temp).localPosition, 0.3f);
                temp++;
            }
            carsParent.GetChild(currentSelectedCarIndex).DOLocalMove(carPositionsParent.GetChild(centerPoint).localPosition, 0.3f);
        }

        #endregion




    }
}