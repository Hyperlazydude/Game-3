using UnityEngine;

public static class CollisionUtilities
{
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