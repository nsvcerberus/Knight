using Fight.Userinterface.Global;
using UnityEngine;

namespace Fight.Level.UserInterface
{
    public sealed class Layout : AbstractLayout
    {
        [SerializeField] private Background background;


        protected override void Awake()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            background.Hidden += Disable;
        }


        public void Hide()
        {
            background.PlayAnimationHide();
        }
    }
}