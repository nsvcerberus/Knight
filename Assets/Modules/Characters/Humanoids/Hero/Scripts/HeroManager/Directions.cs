using System;
using UnityEngine;

namespace Fight.Gameplay.Hero
{
    public class Directions
    {
        public event Func<Vector3> GetMoveDirectionForwardFromAvatar;

        public event Func<Vector3> GetMoveDirectionForward;
        public event Func<Vector3> GetMoveDirectionForwardRight;
        public event Func<Vector3> GetMoveDirectionForwardLeft;
        public event Func<Vector3> GetMoveDirectionBack;
        public event Func<Vector3> GetMoveDirectionBackRight;
        public event Func<Vector3> GetMoveDirectionBackLeft;
        public event Func<Vector3> GetMoveDirectionLeft;
        public event Func<Vector3> GetMoveDirectionRight;

        public Vector3 OnGetMoveDirectionForwardFromAvatar() => GetMoveDirectionForwardFromAvatar.Invoke();

        public Vector3 OnGetMoveDirectionForward() => GetMoveDirectionForward.Invoke();
        public Vector3 OnGetMoveDirectionForwardRight() => GetMoveDirectionForwardRight.Invoke();
        public Vector3 OnGetMoveDirectionForwardLeft() => GetMoveDirectionForwardLeft.Invoke();
        public Vector3 OnGetMoveDirectionBack() => GetMoveDirectionBack.Invoke();
        public Vector3 OnGetMoveDirectionBackRight() => GetMoveDirectionBackRight.Invoke();
        public Vector3 OnGetMoveDirectionBackLeft() => GetMoveDirectionBackLeft.Invoke();
        public Vector3 OnGetMoveDirectionLeft() => GetMoveDirectionLeft.Invoke();
        public Vector3 OnGetMoveDirectionRight() => GetMoveDirectionRight.Invoke();
    }
}