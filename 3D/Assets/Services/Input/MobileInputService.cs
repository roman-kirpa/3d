using Interfaces;
using UnityEngine;

namespace Services.Input
{
    public class MobileInputService : IInputService
    {
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";

        public Vector2 Axis => new Vector2(GetAxis(_horizontal), GetAxis(_vertical));

        private float GetAxis(string axis)
        {
            return SimpleInput.GetAxis(axis);
        }
    }
}
