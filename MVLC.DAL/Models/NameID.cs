using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVLC.DAL.Classes
{
    public class NameID
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<NameID> GetClassNameIDByTerm(string Term) { throw new NotImplementedException(); }
        public List<NameID> GetClassNameIDByPersonID(int id) { throw new NotImplementedException(); }
        public List<NameID> GetClassNameIDByTutorID(int id) { throw new NotImplementedException(); }
        public List<NameID> GetClassNameIDByStudentID(int id) { throw new NotImplementedException(); }
        public List<NameID> GetTutorNameIDByTerm(string Term) { throw new NotImplementedException(); }
        public List<NameID> GetStudentNameIDByTerm(string Term) { throw new NotImplementedException(); }
    }
}
