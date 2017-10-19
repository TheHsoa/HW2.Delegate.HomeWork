using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    internal class ContactModel : IModel
    {
        public string Value { get; set; }

        public ContactModel(Contact contact)
        {
            Value = contact.Value;
        }
    }
}
