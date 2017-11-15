using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    public class ContactModel
    {
        public string Value { get; set; }

        public ContactModel(Contact contact)
        {
            Value = contact.Value;
        }
    }
}
