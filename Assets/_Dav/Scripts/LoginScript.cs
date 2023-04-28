using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace Dav
{
    public class LoginScript : MonoBehaviour
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
            if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrWhiteSpace(loginEmail.text))
            {
                GameManager.instance.ShowPopup("Enter Valid Email");
                return;
            }
            if (string.IsNullOrEmpty(loginPassword.text) || string.IsNullOrWhiteSpace(loginPassword.text))
            {
                GameManager.instance.ShowPopup("Enter Valid Password");
                return;
            }
            var request = new LoginWithEmailAddressRequest()
            {
                Email = loginEmail.text,
                Password = loginPassword.text
            };

            GameManager.instance.ShowLoadingPanel();
            PlayFabClientAPI.LoginWithEmailAddress(request, LogInSuccess, OnError);
        }

        private void LogInSuccess(LoginResult obj)
        {
            GameManager.instance.ShowPopup("Login Successfull");
            GameManager.instance.HideLoadingPanel();
        }
    }
}