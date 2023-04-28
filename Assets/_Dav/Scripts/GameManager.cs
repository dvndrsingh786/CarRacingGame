using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dav
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [Header("UI Panels")]
        [SerializeField] GameObject loadingPanel;
        [SerializeField] GameObject popupPanel;
        [SerializeField] TextMeshProUGUI popupText;

        private void Awake()
        {
            if(instance == null)
            instance = this;
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        #region UI Panels
        public void ShowLoadingPanel()
        {
            loadingPanel.SetActive(true);
        }

        public void HideLoadingPanel()
        {
            loadingPanel.SetActive(false);
        }

        public void ShowPopup(string _popupText, float popupTime = 1.5f)
        {
            popupText.text = _popupText;
            popupPanel.SetActive(true);
            Invoke(nameof(HidePopUp), popupTime);
        }

        void HidePopUp()
        {
            popupPanel.SetActive(false);
        }

        #endregion

        public void SavePlayerData()
        {
            PlayerData.instance = PlayerData.instance;
        }
    }
}