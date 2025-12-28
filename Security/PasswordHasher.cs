namespace HelpDesk.Security
{
    public static class PasswordHasher
    {
        // Method to turn password into hash
        public static string Hash(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        // Method to check if password matches hash
        public static bool Verify(string password, string hash)
            => BCrypt.Net.BCrypt.Verify(password, hash);
    }

}