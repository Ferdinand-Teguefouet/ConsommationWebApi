using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiDAL.Entities;
using WebApiDAL.Interface;

namespace WebApiDAL
{
    public class ContactRequesterService : IContactRequesterService
    {
        // url de base de l'API
        private string url = "https://localhost:44338/";
        // champ de type HttpClient
        private HttpClient _client;

        #region Constructeur
        public ContactRequesterService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        } 
        #endregion

        #region Utilisation du "HttpClient" GetAsync() pour récupérer les contacts
        public IEnumerable<Contact> GetAll()
        {
            using (HttpResponseMessage message = _client.GetAsync("api/contact/").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
            }
        }
        #endregion

        #region Utilisation du "HttpClient" GetAsync() pour récupérer un contact grâce à l'Id
        public Contact GetById(int id)
        {
            using (HttpResponseMessage message = _client.GetAsync("api/contact/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }
        #endregion

        #region Utilisation du "HttpContent" PostAsync() pour ajouter un contact
        public void InsertContact(ContactForm c)
        {
            string jsonBody = JsonConvert.SerializeObject(c);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PostAsync("api/contact", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }
                }
            }
        }
        #endregion

        #region Utilisation du "HttpContent" PutAsync() pour mettre à jour un contact
        public void Update(ContactForm contactForm)
        {
            string json = JsonConvert.SerializeObject(contactForm);

            using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _client.PutAsync("api/contact", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }
                }
            }
        }
        #endregion

        #region Utilisation du "HttpClient" DeleteAsync() pour supprimer un contact
        public void Delete(int id)
        {
            using (HttpResponseMessage message = _client.DeleteAsync("api/contact/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(message.StatusCode.ToString());
                }
            }
        } 
        #endregion
    }
}
