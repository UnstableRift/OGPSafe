using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace AD0260
{
    public class LoadAnyScene : NetworkBehaviour
    {
        [SerializeField] private string _sceneName;
        public void LoadSingleScene()
        {
            NetworkManager.SceneManager.LoadScene(_sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        public void LoadAdditionalScene()
        {
            NetworkManager.SceneManager.LoadScene(_sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    } 
}
