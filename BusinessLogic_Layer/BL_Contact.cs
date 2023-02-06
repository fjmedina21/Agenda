using ContactEntity;
using Data_Layer;


namespace BusinessLogic_Layer
{
    public class BL_Contact
    {
        D_Contact data = new D_Contact();

        public List<E_Contact> contactsRecord(string search)
        {
            return data.ContactsRecord(search);
        }

        public void insertContact(E_Contact c)
        {
            data.insertContact(c);
        }

        public void updateContact(E_Contact c)
        {
            data.updateContact(c);
        }

        public void deleteContact(E_Contact c)
        {
            data.deleteContact(c);
        }



    }
}