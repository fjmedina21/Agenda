namespace ContactEntity
{
    public class E_Contact
    {
        private string _ContactCode;
        private string _FirstName;
        private string _LastName;
        private DateTime _Birthdate;
        private string _Address;
        private string _Gender;
        private string _CivilStatus;
        private string _Movil;
        private string _Email;

        public string ContactCode { get => _ContactCode; set => _ContactCode = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public DateTime Birthdate { get => _Birthdate; set => _Birthdate = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Gender { get => _Gender; set => _Gender = value; }
        public string CivilStatus { get => _CivilStatus; set => _CivilStatus = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Email { get => _Email; set => _Email = value; }
    }
}