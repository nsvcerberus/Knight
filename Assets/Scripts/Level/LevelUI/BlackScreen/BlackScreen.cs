using UnityEngine;
using Fight.Installers.Level.Gameplay;
using Zenject;

namespace Fight.Level.UserInterface
{
    public class BlackScreen : MonoBehaviour
    {
        [Inject] private GameplayManager gameplayManager;
        [SerializeField] private Layout layout;


        private void Awake()
        {
            SubscribeToEvents();

            if (gameplayManager.states.State == States.Types.Start)
            {
                layout.Enable();
                layout.Hide();
            }   
        }

        private void SubscribeToEvents()
        {
            layout.Disabled += StartGameplay;
        }


        private void StartGameplay()
        {
            gameplayManager.states.SetStatePlay();
        }
    }
}