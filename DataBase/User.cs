using System;
using BaseData;


namespace ClientUser
{
    public class User 
    {
        private int id;
        private string name;
        private string sname;
        private string mname;
        private DateTime birth;
        private string phone;
        private string email;
        private string passport;


        public int Id 
        { 
          
            get { return id;}
            set
            {
                id = value;
            }
            
        }
        public User()
        {
            while (true)
            {
                id = BClaim.GenerateID(4);
                if (BaseDataLite.CheckUsersID(id)) { break; }
            }
        }
        public string Name{ get { return name; } set { name = value; } }
        public string SecoundName { get { return sname; } set { sname = value; } }
        public string MiddleName { get { return mname; } set { mname = value; } }
        public DateTime BirthDay { get { return birth; }set { birth = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Passport { get { return passport; } set { passport = value; } }






    }
}
