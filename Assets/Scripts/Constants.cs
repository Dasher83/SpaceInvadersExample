public static class Constants
{
    public static class Ship
    {
        public const float DefaultMovementSpeed = 8f;
        public const float MaxSpeed = 10f;
    }

    public static class Bullet
    {
        public const float DefaultSpeed = 30f;
        public const float SpawnOffset = 0.75f;
    }

    public static class Axes
    {
        public const string Horizontal = "Horizontal";
    }

    public static class GameObjects
    {
        public const string RightOuterBound = "RightOuterBound";
        public const string LeftOuterBound = "LeftOuterBound";
        public const string ShipSpawnPoint = "ShipSpawnPoint";
    }

    public static class Tags
    {
        public const string Player = "Player";
    }

    public static class HealthBar
    {
        public const float DefaultMaximum = 10f;
        public const float Minimum = 0f;
    }

    public static class ScoreDisplay
    {
        public const float MaxScore = 1000000;
    }
}
