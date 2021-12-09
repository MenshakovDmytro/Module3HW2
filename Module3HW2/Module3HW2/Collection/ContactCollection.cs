using System.Collections.Generic;
using Module3HW2.Models;

namespace Module3HW2.Collections
{
    public class ContactCollection
    {
        private readonly Dictionary<string, string> _alphabet;
        private Dictionary<string, List<Contact>> _dictionary;
        private string _culture;

        public ContactCollection()
        {
            _dictionary = new Dictionary<string, List<Contact>>();
            _alphabet = new Dictionary<string, string>();
            _culture = "en-EN";
        }

        public void AddAlphabet(string key, string value)
        {
            _alphabet.Add(key, value);
        }

        public void SetCulture(string culture)
        {
            if (culture.Equals(_culture))
            {
                return;
            }

            _culture = culture;
            var oldValues = _dictionary;
            _dictionary = new Dictionary<string, List<Contact>>();
            foreach (var item in oldValues)
            {
                foreach (var value in item.Value)
                {
                    Add(value);
                }
            }
        }

        public void Add(Contact contact)
        {
            string key = null;
            var firstSymbol = contact.FullName.Trim()[0].ToString();
            if (_alphabet[_culture].IndexOf(firstSymbol, System.StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                key = firstSymbol;
            }
            else if (char.IsDigit(firstSymbol[0]))
            {
                key = "0-9";
            }
            else
            {
                key = "#";
            }

            AddToSection(key, contact);
        }

        public IEnumerator<KeyValuePair<string, List<Contact>>> GetEnumerator()
        {
            foreach (var item in _dictionary)
            {
                yield return item;
            }
        }

        private void AddToSection(string key, Contact contact)
        {
            List<Contact> list;
            if (!_dictionary.TryGetValue(key, out list))
            {
                list = new List<Contact>();
                _dictionary[key] = list;
            }

            list.Add(contact);
        }
    }
}