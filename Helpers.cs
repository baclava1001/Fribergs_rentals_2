using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Fribergs_rentals_2.Models;

namespace Fribergs_rentals_2
{
    /// <summary>
    /// This class gathers helper methods to be used anywhere in the rest of the code
    /// </summary>
    public static class Helpers
    {
        // Retrieves the type from the cookie holding the logged in user
        public static object GetUserRole(ISession session)
        {
            // Initialize object for later use
            object user = null;

            // Get the string inside the cookie
            string loggedInCookie = session.GetString("LoggedInCookie");

            // If cookie isn't empty
            if (!string.IsNullOrEmpty(loggedInCookie))
            {
                // Deserialize the object from json-string
                JObject jObject = JsonConvert.DeserializeObject<JObject>(loggedInCookie);

                // If the loggedInCookie contains the value "Administrator" for the key "Role"
                if (jObject["Role"].ToString() == "Administrator")
                {
                    // Make user an Administrator object
                    user = jObject.ToObject<Administrator>();
                }
                // If the loggedInCookie contains the value "Customer" for the key "Role"
                else if (jObject["Role"].ToString() == "Customer")
                {
                    // Make user a Customer object
                    user = jObject.ToObject<Customer>();
                }
            }
            return user;
        }
    }
}
