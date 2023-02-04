using UnityEngine;

namespace DefaultNamespace
{
    public static class Collision2DExtensions
    {
        public static bool WasPlayer(this Collision2D collision)
        {
            return collision.collider.GetComponent<PlayerMovementController>() != null;
        }

        public static bool WasBottom(this Collision2D collision)
        {
            return collision.contacts[0].normal.y > 0.75;
        }
        
        public static bool WasTop(this Collision2D collision)
        {
            return collision.contacts[0].normal.y < -0.75;
        }
        
        public static bool WasSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.x < -0.75 
                   || collision.contacts[0].normal.x > 0.75;
        }
    }
}