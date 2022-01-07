using Assets.Interfaces;
using UnityEngine;

namespace Assets.Services.Input
{
    public class UnityInputService : IInputService
    {
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";

        public Vector2 Axis => new UnityEngine.Vector2(GetAxis(_horizontal), GetAxis(_vertical));

        private float GetAxis(string axis)
        {
            return UnityEngine.Input.GetAxis(axis);
        }
    }
}
