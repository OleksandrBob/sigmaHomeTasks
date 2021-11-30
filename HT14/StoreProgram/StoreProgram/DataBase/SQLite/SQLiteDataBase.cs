using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace StoreProgram.DataBase
{
    class SQLiteDataBase
    {
        public SQLiteConnection _connection;

        private  SQLiteDataBase() { }
        public SQLiteDataBase(string connectionPath) 
        {
            this._connection = new SQLiteConnection(connectionPath);

            try
            {
                this._connection.Open();
                this._connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Can't connect to SQLite data base with this parameters");
            }
        }

        public void ExecuteSQL(string sql) 
        {
            try
            {
                this._connection.Open();
                SQLiteCommand command = new SQLiteCommand(sql, this._connection);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Invalid sql - impossible to execute");
            }
            finally 
            {
                _connection.Close();
            }          
        }
        public List<T> GetRecords<T>(string stringCommand, Func<IDataRecord, T> InstanceConstructor)
        {
            List<T> resultList = new List<T>();


            _connection.Open();
            try
            {
                SQLiteCommand command = new SQLiteCommand(stringCommand, _connection);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultList.Add(InstanceConstructor(reader));
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Can't use this command to get information from data base. Change your command");
            }
            _connection.Close();


            return resultList;
        }
    }
}
