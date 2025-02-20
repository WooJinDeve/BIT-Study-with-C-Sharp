﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0425_MemberService
{
    internal class WbDB
    {
        private string connstring = null;

        private SqlConnection con = null;

        #region OPEN and Close
        
        public bool Open(string server, string database, string id, string pw)
        {
            connstring = String.Format( "Server={0};database={1};uid={2};pwd={3}",server, database, id, pw);
            return InnerOpen();
        }

        public bool Open(string sql)
        {
            connstring = String.Format(sql);
            return InnerOpen();
        }
        private bool InnerOpen()
        {
            try
            {
                con = new SqlConnection(connstring);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                return true;
            }
            return false;
        }
        #endregion

        #region Query 메서드

        public void CommandNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            if (cmd.ExecuteNonQuery() < 1)  //영향을 받은 row의 갯수 
                throw new Exception("실패");
        }

        public string CommandQuery(string sql)
        {
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();
            string msg = "";
            //ROW데이터 정보
            while (reader.Read())
            {                
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    msg += reader[i] + "#";
                }
                msg += "$";                    
            }
            
            reader.Close();            
            return msg;
        }

        //--추가
        public List<Member> CommandQuery1(string sql)
        {
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();
            List<Member> members = new List<Member>();
            //ROW데이터 정보
            while (reader.Read())
            {
                members.Add(new Member(reader[0].ToString(), reader[1].ToString()));
            }

            reader.Close();
            return members;
        }

        //추가--
        public Member CommandQuery2(string sql)
        {
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();
            Member member = null;
            //ROW데이터 정보
            while (reader.Read())
            {
                member = new Member(reader[0].ToString(), reader[1].ToString());
            }

            reader.Close();
            return member;
        }


        public object CommandScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteScalar();
        }

        #endregion    
    }
}
