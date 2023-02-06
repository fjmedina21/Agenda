using ContactEntity;
using BusinessLogic_Layer;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class Menu_View : Form
    {
        public Menu_View()
        {
            InitializeComponent();
        }

        E_Contact contact = new E_Contact();
        BL_Contact business = new BL_Contact();

        private  void showContact(string search)
        {
           BL_Contact business = new BL_Contact();

            contactsTbl.DataSource = business.contactsRecord(search);

        }

        private void clearForm()
        {
            firstNameTxt.Clear();
            lastNameTxt.Clear();
            addressTxt.Clear();
            genderCBx.Text = "";
            civilStatusCBx.Text = "";
            movilTxt.Clear();
            emailTxt.Clear();
        }

        private void Menu_View_Load(object sender, EventArgs e)
        {
            birthdatePkr.CustomFormat = "yyyy-MM-dd";
            birthdatePkr.Format = DateTimePickerFormat.Custom;
            showContact(searchBarTxt.Text);
        }

        private void newContact(object sender, EventArgs e)
        {
            if(firstNameTxt.Text.Length == 0 || lastNameTxt.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un nombre y apellido para agregar un nuevo contacto");
            }
            else
            {
                contact.FirstName = firstNameTxt.Text;
                contact.LastName = lastNameTxt.Text;
                contact.Birthdate = birthdatePkr.Value;
                contact.Address = addressTxt.Text;
                contact.Gender = genderCBx.Text;
                contact.CivilStatus = civilStatusCBx.Text;
                contact.Movil = movilTxt.Text;
                contact.Email = emailTxt.Text;

                business.insertContact(contact);
                clearForm();
                showContact(searchBarTxt.Text);
            }
        
        }

        private void editContact(object sender, EventArgs e)
        {
            if (contactsTbl.SelectedRows.Count > 0)
            {
                contact.ContactCode = contactsTbl.CurrentRow.Cells[0].Value.ToString();

                firstNameTxt.Text = contactsTbl.CurrentRow.Cells[1].Value.ToString();
                lastNameTxt.Text = contactsTbl.CurrentRow.Cells[2].Value.ToString();
                birthdatePkr.Text = contactsTbl.CurrentRow.Cells[3].Value.ToString();
                addressTxt.Text = contactsTbl.CurrentRow.Cells[4].Value.ToString();
                genderCBx.Text = contactsTbl.CurrentRow.Cells[5].Value.ToString();
                civilStatusCBx.Text = contactsTbl.CurrentRow.Cells[6].Value.ToString();
                movilTxt.Text = contactsTbl.CurrentRow.Cells[7].Value.ToString();
                emailTxt.Text = contactsTbl.CurrentRow.Cells[8].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione el contacto que desea editar");
            }
        }
                
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

                contact.FirstName = firstNameTxt.Text;
                contact.LastName = lastNameTxt.Text;
                contact.Birthdate = birthdatePkr.Value;
                contact.Address = addressTxt.Text;
                contact.Gender = genderCBx.Text;
                contact.CivilStatus = civilStatusCBx.Text; 
                contact.Movil = movilTxt.Text;  
                contact.Email = emailTxt.Text;

                business.updateContact(contact);
                clearForm();
                showContact(searchBarTxt.Text);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (contactsTbl.SelectedRows.Count > 0)
            {

                contact.ContactCode = contactsTbl.CurrentRow.Cells[0].Value.ToString();
                business.deleteContact(contact);
                showContact(searchBarTxt.Text);
            }
            else
            {
                MessageBox.Show("Seleccione el contacto que desea eliminar");
            }
        }

        private void clearFieldsBtn_Click(object sender, EventArgs e)
        {
            clearForm();    
        }
    }
}