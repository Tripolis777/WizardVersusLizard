// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public static class Initialization
    {
        private const string INIT_SCENE_NAME = "InitScene";
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static async void InitScene()
        {
            var scene = SceneManager.GetSceneByName(INIT_SCENE_NAME);
            if (!scene.isLoaded)
                await SceneManager.LoadSceneAsync(INIT_SCENE_NAME, LoadSceneMode.Additive);
        }
    }
}