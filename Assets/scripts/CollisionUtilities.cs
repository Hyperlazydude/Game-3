using System.Linq;
using UnityEngine;

public static class CollisionUtilities
{

    public enum CollisionPosition
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT
    }

    public static CollisionPosition GetCollisionPosition(Collision2D collision)
    {
        ContactPoint2D[] contacts = collision.contacts;

        Vector2 point1 = contacts.FirstOrDefault().point;
        Vector2 point2 = contacts.LastOrDefault().point;

        Bounds otherColliderBounds = collision.collider.bounds;
        float ignore, maxPoint;

        if (point1.x == point2.x)
        {
            CollisionUtilities.GetBoundsXLimits(otherColliderBounds, out ignore, out maxPoint);
            return Mathf.Abs(maxPoint - point1.x) <= 0.05 ? CollisionPosition.LEFT : CollisionPosition.RIGHT;
        }

        CollisionUtilities.GetBoundsYLimits(otherColliderBounds, out ignore, out maxPoint);
        return Mathf.Abs(maxPoint - point1.y) <= 0.05 ? CollisionPosition.BOTTOM : CollisionPosition.TOP;

    }

    public static bool FullyContactingPlatform (Bounds platform, Bounds inner)
    {
        float outerMin, outerMax;
        float innerMin, innerMax;

        CollisionUtilities.GetBoundsXLimits(platform, out outerMin, out outerMax);
        CollisionUtilities.GetBoundsXLimits(inner, out innerMin, out innerMax);

        return outerMin <= innerMin && outerMax >= innerMax;
    }

    public static void GetBoundsXLimits(Bounds bounds, out float min, out float max)
    {
        float boundsCenter = bounds.center.x;
        float halfWidth = bounds.extents.x;

        min = boundsCenter - halfWidth;
        max = boundsCenter + halfWidth;
    }

    public static void GetBoundsYLimits(Bounds bounds, out float min, out float max)
    {
        float boundsCenter = bounds.center.y;
        float halfHeight = bounds.extents.y;

        min = boundsCenter - halfHeight;
        max = boundsCenter + halfHeight;
    }
}