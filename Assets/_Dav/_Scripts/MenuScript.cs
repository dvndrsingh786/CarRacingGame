using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace Dav
{
    public class MenuScript : MonoBehaviour
    {
        [Header("Signup Objects")]
        [SerializeField] GameObject signupPanel;
        [SerializeField] TMP_InputField signupName;
        [SerializeField] TMP_InputField signupEmail;
        [SerializeField] TMP_InputField signupPassword;
        [SerializeField] TMP_InputField signupConfirmPassword;

        [Header("Login Objects")]
        [SerializeField] GameObject loginPanel;
        [SerializeField] TMP_InputField loginEmail;
        [SerializeField] TMP_InputField loginPassword;

        public void SignUp()
        {
            if(string.IsNullOrEmpty(signupName.text) || string.IsNullOrWhiteSpace(signupName.text))
            {
                GameManager.instance.ShowPopup("Enter Valid Name");
                return;
            }
            if (string.IsNullOrEmpty(signupEmail.text) || string.IsNullOrWhiteSpace(signupEmail.text))
            {
                GameManager.instance.ShowPopup("Enter Valid Email");
                return;
            }
            if (string.IsNullOrEmpty(signupPassword.text) || string.IsNullOrWhiteSpace(signupPassword.text))
            {
                GameManager.instance.ShowPopup("Enter Valid Password");
                return;
            }
            if (!string.Equals(signupPassword.text, signupConfirmPassword.text))
            {
                GameManager.instance.ShowPopup("Passwords do not match");
                return;
            }
            var request = new RegisterPlayFabUserRequest()
            {
                DisplayName = signupName.text,
                Email = signupEmail.text,
                Password = signupPassword.text,
                RequireBothUsernameAndEmail = false
            };
            GameManager.instance.ShowLoadingPanel();
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        }
        private void OnRegisterSuccess(RegisterPlayFabUserResult obj)
        {
            GameManager.instance.ShowPopup("Registered Successfully");
            GameManager.instance.HideLoadingPanel();
        }

        private void OnError(PlayFabError obj)
        {
            GameManager.instance.ShowPopup(obj.ErrorMessage.ToString());
            
            GameManager.instance.HideLoadingPanel();
        }

        public void Login()
        {
            GameManager.instance.ShowPopup("Not Implemented Yet");
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}