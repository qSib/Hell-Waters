using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public PathCreator pathCreator1;
        public PathCreator pathCreator2;
        public PathCreator pathCreator3;
        public PathCreator pathCreator4;
        int pathCount;
        public EndOfPathInstruction endOfPathInstruction;
        float speed;
        float distanceTravelled;

        void Start()
        {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }

            CheckPath();
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        void CheckPath()
        {
            if (pathCount == 1)
            {
                pathCreator = pathCreator1;
            }
            else if (pathCount == 2)
            {
                pathCreator = pathCreator2;
            }
            else if (pathCount == 3)
            {
                pathCreator = pathCreator3;
            }
            else if (pathCount == 4)
            {
                pathCreator = pathCreator4;
            }
        }

        public void SetPath(int pth)
        {
            pathCount = pth;
        }

        public void SetSpeed(float spd)
        {
            speed = spd;
        }

    }
}