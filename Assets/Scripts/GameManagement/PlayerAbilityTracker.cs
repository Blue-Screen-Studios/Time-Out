namespace GameManagement
{
    public static class PlayerAbilityTracker
    {
        public static bool[] abilites;

        public static void SetValues(bool canDoubleJump, bool canDash, bool canBecomeDrone, bool canDropBomb)
        {
            abilites[0] = canDoubleJump;
            abilites[1] = canDash;
            abilites[2] = canBecomeDrone;
            abilites[3] = canDropBomb;
        }

        public static bool[] GetValues() { return abilites; }

        public static void SetDoubleJump(bool enable) { abilites[0] = enable; }
        public static void SetDash(bool enable) { abilites[1] = enable; }
        public static void SetBecomeDrone(bool enable) { abilites[0] = enable; }
        public static void SetDropBomb(bool enable) { abilites[0] = enable; }

        public static bool CanDoubleJump() { return abilites[0]; }
        public static bool CanDash() { return abilites[1]; }
        public static bool CanBecomeDrone() { return abilites[2]; }
        public static bool CanDropBomb() { return abilites[3]; }
    }
}
