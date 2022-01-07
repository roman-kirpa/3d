using UnityEngine;

namespace Assets.CameraConfigs
{
    public class CameraFollow : MonoBehaviour
    {
        public float Distance;
        public float AngleX;
        public float AngleY;
        public float OffsetY;

        [SerializeField]
        private Transform _following;

        public void Follow(GameObject gameObject)
        {
            _following = gameObject.transform;
        }

        private void LateUpdate()
        {
            if (_following == null)
            {
                return;
            }
            var rotation = Quaternion.Euler(AngleX, AngleY, 0);
            var position = rotation * new Vector3(0, 0, -Distance) + GetFollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        private Vector3 GetFollowingPosition()
        {
            var followingPosition = _following.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}
