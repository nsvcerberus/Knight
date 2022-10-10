using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Fight.Level.UserInterface
{
    public class Background : MonoBehaviour
    {
        public event Action Hidden;

        [SerializeField] private Image image;
        [SerializeField] private float speedAnimationHide;


        public void PlayAnimationHide()
        {
            image
                .DOFade(0, speedAnimationHide)
                .OnComplete(() => Hidden?.Invoke());
        }
    }
}