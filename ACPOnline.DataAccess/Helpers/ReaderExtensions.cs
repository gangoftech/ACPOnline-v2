using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACPOnline.DataAccess.Helpers
{
    public static class ReaderExtensions
    {

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string name)
        {
            var col = reader.GetOrdinal(name);
            return reader.IsDBNull(col) ?
                        (DateTime?)null :
                        (DateTime?)reader.GetDateTime(col);
        }

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ?
                        (DateTime?)null :
                        (DateTime?)reader.GetDateTime(index);
        }

        public static Int32? GetNullableInt32(this SqlDataReader reader, string name)
        {
            var col = reader.GetOrdinal(name);
            return reader.IsDBNull(col) ?
                        (Int32?)null :
                        (Int32?)reader.GetInt32(col);
        }

        public static Int32? GetNullableInt32(this SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ?
                        (Int32?)null :
                        (Int32?)reader.GetInt32(index);
        }
    }
}
