using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Рейтинг
{

    public enum ServerStatusEnum
    {
        Get,
        Add,
        Update,
        Delete

    }
    public struct ServerSendStruct
    {
        string db;
        string sqldata;
        int id;
        public string DB { get { return db; } }
        public string SQLData { get { return sqldata; } }
        public int ID { get { return id; } }
        public void set(string db, string sql, int id) {

            this.db = db;
            this.sqldata = sql;
            this.id = id;
        }
    }

    [DataContract]
    public abstract class ServerObj
    {
        [DataMember]
        int id;
       
        public int Id { get { return id; } }

       
        protected string db_tabel;

        protected void setID(int id) {
            this.id = id;
        }
        public virtual string GetSqlObjInfo() {

            return "db_tabel:" + db_tabel + "; id:" + id;

        }
    }
}
