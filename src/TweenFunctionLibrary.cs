using System;

namespace EliottChen.CSharpToolkit
{
    public static class TweenFunctionLibrary
    {
        /// <summary>
        /// Transform a ratio in a ease out cubic function, where x is the ratio
        /// </summary>
        /// <param name="x"> should be normalized between 0 and 1</param>
        /// <returns></returns>
        static public float EaseOutCubic(float x)
        {
            return 1f - (float)Math.Pow(1f - x, 3f);
        }

        static public float EaseOutQuint(float x)
        {
            return 1 - (float)MathF.Pow(1f - x, 5);
        }
    }
}
