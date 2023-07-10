namespace SocialMedia.Models
{
    public static class Repositories
    {
        private static List<User> applications = new List<User>();
        public static IEnumerable<User> Applications => applications;
        public static void Add(User user){
            applications.Add(user);
        }
    }
        

    
}