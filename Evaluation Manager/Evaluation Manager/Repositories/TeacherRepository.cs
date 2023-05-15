using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Evaluation_Manager.Repositories
{
    public class TeacherRepository
    {
        public static Teacher GetTeacher(string username)
        {
            return FetchTeacher($"SELECT * FROM Teachers WHERE Username = '{username}'");
        }

        public static Teacher GetTeacher(int id)
        {
            return FetchTeacher($"SELECT * FROM Teachers WHERE Id = {id}");
        }

        private static Teacher FetchTeacher(string sql)
        {
            Teacher teacher = null;

            DB.OpenConnection();

            var dr = DB.GetDataReader(sql);

            if (dr.HasRows)
            {
                dr.Read();
                teacher = CreateObject(dr);
            }

            DB.CloseConnection();

            return teacher;
        }

        private static Teacher CreateObject(SqlDataReader dr)
        {
            return new Teacher()
            {
                Id = int.Parse(dr["Id"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                Username = dr["Username"].ToString(),
                Password = dr["Password"].ToString()
            };
        }
    }
}
