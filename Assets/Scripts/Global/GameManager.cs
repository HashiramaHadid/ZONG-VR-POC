using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Global
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private GameStateManager m_GameStateManager;

        public static Action<bool> Aim;
        public static Action<Transform,Action> MovePlayer;
                
        private GameplayData m_GameplayData;
        
        public Camera MainCamera => m_GameplayData.CameraManager.MainCameraObject;
        public Transform GlobalBillBoardTarget => m_GameplayData.CameraManager.MainCameraTransform;
        
        public override void Init()
        {
            base.Init();
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = Int32.MaxValue;
        }

        public void ChangeGameState(GameState gameState)
        {
            m_GameStateManager.ChangeGameState(gameState);
        }
        
        public void RegisterGameplayData(GameplayData gameplayData)
        {
            m_GameplayData = gameplayData;
            ChangeGameState(GameState.Gameplay);
        }

        public void UnRegisterGameplayData(GameplayData gameplayData)
        {
            if (m_GameplayData == gameplayData)
                m_GameplayData = null;
        }
    }
}
