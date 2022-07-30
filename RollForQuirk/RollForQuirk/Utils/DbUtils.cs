using Microsoft.Data.SqlClient;

namespace RollForQuirk.Utils
{
    public class DbUtils
    {
        public static string GetNullableString(SqlDataReader reader, string target)
        {
            var ordinal = reader.GetOrdinal(target);

            if (reader.IsDBNull(ordinal))
            { 
                return null;
            }
            return reader.GetString(ordinal);
        }

        public static int GetNullableInt(SqlDataReader reader, string target)
        {
            var ordinal = reader.GetOrdinal(target);

            if (reader.IsDBNull(ordinal))
            {
                return 0;
            }
            return reader.GetInt32(ordinal);
        }
    }
}
