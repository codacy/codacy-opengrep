import java.io.Console;
import de.hybris.platform.servicelayer.search.FlexibleSearchQuery;

class Program
    {
        public static void main(String[] args)
        {
            private static final String PASSWORD = "password" ; // Issue: Hardcoded password
            private static final String API_KEY = "api_key" ; // Issue: Hardcoded API key
            private static final String API_SECRET = "api_secret" ; // Issue: Hardcoded API secret
            final FlexibleSearchQuery query = new FlexibleSearchQuery("SELECT {a.pk} FROM {TEST AS a} WHERE {a.uid} ="+ uid +" AND {a.visibleInAddressBook} = true");

            final FlexibleSearchQuery okquery = new FlexibleSearchQuery(
                "SELECT {a.pk} FROM {TEST AS a} WHERE {a.uid} = ?uid AND {a.visibleInAddressBook} = true"
            );
            okquery.addQueryParameter("uid", uid);
            System.out.println("This is a security risk: " + PASSWORD);
            System.out.println("This is a security risk: " + API_KEY);
            System.out.println("This is a security risk: " + API_SECRET);
        }
    }

