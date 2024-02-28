using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BITCollege_TA.Models
{
    public static class StoredProcedure
    {

        /// <summary>
        /// Retrieves the next number based on the discriminator.
        /// </summary>
        /// <param name="discriminator">The discriminator value.</param>
        /// <returns>The next number if successful, otherwise null.</returns>
        public static long? NextNumber(string discriminator)
        {
            try
            {
                long? returnValue = 0;
                using (SqlConnection connection = new SqlConnection("Data Source=localhost; " +
                    "Initial Catalog=BITCollege_FLContext;Integrated Security=True"))
                {
                    using (SqlCommand storedProcedure = new SqlCommand("next_number", connection))
                    {
                        storedProcedure.CommandType = CommandType.StoredProcedure;
                        storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);
                        SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        storedProcedure.Parameters.Add(outputParameter);
                        connection.Open();
                        storedProcedure.ExecuteNonQuery();
                        //Cast long?
                        returnValue = (long?)outputParameter.Value;
                    }
                }
                return returnValue;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
